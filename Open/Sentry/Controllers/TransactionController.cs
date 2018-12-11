using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Domain.Notification;
using Open.Facade.Bank;
namespace Open.Sentry.Controllers {
    [Authorize]
    public class TransactionController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly ITransactionRepository transactions;
        private readonly IRequestTransactionRepository requests;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationsRepository notifications;
        public static Account BankAccount;

        internal const string properties =
            "ID, AmountInStringFormat, Explanation, ReceiverAccountId, SenderAccountId, ValidFrom";

        public TransactionController(ITransactionRepository p, IRequestTransactionRepository r, IAccountsRepository a, INotificationsRepository n,
            UserManager<ApplicationUser> uManager) {
            transactions = p;
            requests = r;
            accounts = a;
            notifications = n;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string id, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null){
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortSenderAccount"] = sortOrder == "senderAccount" ? "senderAccount_desc" : "senderAccount";
            ViewData["SortExplanation"] = sortOrder == "explanation" ? "explanation_desc" : "explanation";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            transactions.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            transactions.SortFunction = getSortFunction(sortOrder, id);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            transactions.SearchString = searchString;
            transactions.PageIndex = page ?? 1;
            BankAccount = await accounts.GetObject(id);

            var l = await transactions.LoadTransactionsForAccount(id);
            var viewList = new TransactionViewsList(l);
            foreach (var transaction in viewList) {
                transaction.SenderAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.SenderAccountId));
                transaction.SenderAccount.AspNetUser =
                    await userManager.FindByIdAsync(transaction.SenderAccount.AspNetUserId);
                transaction.ReceiverAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.ReceiverAccountId));
                transaction.ReceiverAccount.AspNetUser =
                    await userManager.FindByIdAsync(transaction.ReceiverAccount.AspNetUserId);
                adjustAmountIfUserIsTransactionSender(transaction, id);
            }

            return View(viewList);
        }

        private void adjustAmountIfUserIsTransactionSender(TransactionView transaction, string id) {
            if (transaction.SenderAccount.ID == id)
            {
                transaction.Amount = -transaction.Amount;
                var receiver = transaction.SenderAccount;
                var receiverId = transaction.SenderAccountId;
                transaction.SenderAccount = transaction.ReceiverAccount;
                transaction.ReceiverAccount = receiver;
                transaction.SenderAccountId = transaction.ReceiverAccountId;
                transaction.ReceiverAccountId = receiverId;
            }
        }
        private Func<TransactionData, object> getSortFunction(string sortOrder, string accountId) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
            if (sortOrder.StartsWith("senderAccount"))
                return y => y.SenderAccountId == accountId
                    ? y.ReceiverAccountId
                    : y.SenderAccountId;
            if (sortOrder.StartsWith("explanation")) return x => x.Explanation;
            if (sortOrder.StartsWith("amount"))
                return y => y.SenderAccountId == accountId
                ? -y.Amount
                : y.Amount; 
            return x => x.ValidFrom;
        }

        public IActionResult Create(string senderId){        
                     return View(TransactionViewFactory.Create(
                         TransactionFactory.CreateTransaction(null, 0, "", senderId, "", DateTime.Now)));
                 }
        
        public IActionResult CreateWithReceiver(string senderId, string receiverId){
            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateTransaction(null, 0, "", senderId, receiverId, DateTime.Now)));
        }
        public IActionResult CreateRequested(decimal amount, string explanation, string senderAccountId, string receiverAccountId)
        {
            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateTransaction(null, amount, explanation, senderAccountId, receiverAccountId, DateTime.Now)));
        }

        public async Task<IActionResult> Details(string id) {
            var c = await transactions.GetObject(id);
            return View(TransactionViewFactory.Create(c));
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] TransactionView model){
            bool receiverExists = await checkIfReceiverAccountExists(model.ReceiverAccountId);

            if (receiverExists) {
                var receiverObject = await accounts.GetObject(model.ReceiverAccountId);
                var senderObject = await accounts.GetObject(model.SenderAccountId);

                bool senderIsOk =
                    validateSender(senderObject,
                        model.Amount); //check if has enough balance and active card
                bool receiverIsOk = validateReceiverAndSender(receiverObject, senderObject); //c

                if (senderIsOk && receiverIsOk) {
                    //receiverBalance
                    receiverObject.Data.Balance = receiverObject.Data.Balance + model.Amount;

                    //senderBalance
                    senderObject.Data.Balance = senderObject.Data.Balance - model.Amount;

                    //Transaction
                    model.ID = Guid.NewGuid().ToString();
                    var transaction = TransactionFactory.CreateTransaction(model.ID, model.Amount,
                        model.Explanation, model.SenderAccountId, model.ReceiverAccountId,
                        DateTime.Now, model.ValidTo);

                    await accounts.UpdateObject(senderObject);
                    await accounts.UpdateObject(receiverObject);
                    await transactions.AddObject(transaction);
                    await generateTransactionNotification(transaction);
                    TempData["Status"] =
                        "Transaction successfully done to " + model.ReceiverAccountId + " from " +
                        model.SenderAccountId +
                        " in the amount of " + model.Amount + ". ";

                    await confirmIfTransactionWasRequested(transaction);
                }
            }
            return RedirectToAction("Index", new {id = model.SenderAccountId});
        }
        private async Task confirmIfTransactionWasRequested(Transaction transaction) {
            var reqs = await requests.GetObjectsList();
            foreach (var req in reqs) {
                if (req.Data.SenderAccountId == transaction.Data.SenderAccountId &&
                    req.Data.ReceiverAccountId == transaction.Data.ReceiverAccountId &&
                    req.Data.Amount == transaction.Data.Amount &&
                    req.Data.Explanation == transaction.Data.Explanation) {
                    req.Data.Status = TransactionStatus.Confirmed;
                    await requests.UpdateObject(req);
                    await generateStatusNotification(req, TransactionStatus.Confirmed);
                }
            }
        }
        private async Task generateTransactionNotification(Transaction transaction) {
            var notification = NotificationFactory.CreateNewTransactionNotification(
                Guid.NewGuid().ToString(), transaction.Data.SenderAccountId,
                transaction.Data.ReceiverAccountId, transaction.Data.Amount,
                false, DateTime.Now);
            await notifications.AddObject(notification);
        }
        private async Task generateStatusNotification(RequestTransaction request, TransactionStatus status)
        {
            var notification = NotificationFactory.CreateRequestStatusNotification(
                Guid.NewGuid().ToString(), request.Data.SenderAccountId,
                request.Data.ReceiverAccountId, request.Data.Amount, status,
                false, DateTime.Now);
            await notifications.AddObject(notification);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWithReceiver([Bind(properties)] TransactionView model){
            return await Create(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequested([Bind(properties)] TransactionView model)
        {
            return await Create(model);
        }
        private async Task<bool> checkIfReceiverAccountExists(string rAccountId)
        {
            var o = await accounts.GetObject(rAccountId);
            if (o.Data.AspNetUserId != "Unspecified") //vb peab seda siin rohkem kontrollima
            {
                return true;
            }

            TempData["Status"] =
                "Receiver account number does not exist in our system. Cannot make transaction!";
            return false;   
        }

        private bool validateReceiverAndSender(Account receiverObject, Account senderObject) {
            string receiverCardStatus = receiverObject.Data.Status;

            if (receiverCardStatus == "Active") {
                if (receiverObject.Data.ID != senderObject.Data.ID)
                {
                    return true;
                }

                TempData["Status"] = "You cannot make transaction to yourself.";
                return false;
            }

            TempData["Status"] = "Receiver's card is not active. Cannot make transaction.";
            return false;
        }

        private bool validateSender(Account senderObject, decimal? amount) {
            decimal? senderBalance = senderObject.Data.Balance;
            string senderCardStatus = senderObject.Data.Status;

            if (senderBalance >= amount) {
                if (senderCardStatus == "Active") {
                    return true;
                }

                TempData["Status"] = "Your card is not active. Cannot make transaction.";
                return false;
            }

            TempData["Status"] = "Your balance is " + senderBalance + " , but transaction amount is " 
            + amount + ". Cannot make transaction.";
            return false;
        }

        public object GetById(string id) {
            return transactions.GetObject(id);
        }
    }
}
