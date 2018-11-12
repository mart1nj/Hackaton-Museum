using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
using Open.Core;

namespace Open.Sentry.Controllers {
    [Authorize]
    public class TransactionController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly ITransactionRepository transactions;
        private readonly UserManager<ApplicationUser> userManager;
        public static Account BankAccount;

        internal const string properties =
            "ID, Amount, Explanation, ReceiverAccountId, SenderAccountId, ValidFrom";

        public static string ErrorMessage;

        public TransactionController(ITransactionRepository p, IAccountsRepository a,
            UserManager<ApplicationUser> uManager) {
            transactions = p;
            accounts = a;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string id, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null){
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortSenderFirstName"] =
                sortOrder == "senderFirstName" ? "senderFirstName_desc" : "senderFirstName";
            ViewData["SortSenderLastName"] = sortOrder == "senderLastName" ? "senderLastName_desc" : "senderLastName";
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            transactions.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            transactions.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            transactions.SearchString = searchString;
            transactions.PageIndex = page ?? 1;
            BankAccount = await accounts.GetObject(id);

            var l = await transactions.LoadTransactionsForAccount(id);

            var viewList = new TransactionViewsList(l);
            var appUser = await userManager.GetUserAsync(HttpContext.User);
            foreach (var transaction in viewList) {
                transaction.SenderAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.SenderAccountId));
                transaction.SenderAccount.AspNetUser =
                    await userManager.FindByIdAsync(transaction.SenderAccount.AspNetUserId);
                transaction.ReceiverAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.ReceiverAccountId));
                transaction.ReceiverAccount.AspNetUser =
                    await userManager.FindByIdAsync(transaction.ReceiverAccount.AspNetUserId);
                adjustAmountIfUserIsTransactionSender(transaction, appUser.Id);
            }

            return View(viewList);
        }

        private void adjustAmountIfUserIsTransactionSender(TransactionView transaction, string id) {
            if (transaction.SenderAccount.AspNetUserId == id)
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
        private Func<TransactionData, object> getSortFunction(string sortOrder) {
            //Todo sorting by first and last name- need to load account and aspnetUser
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
            if (sortOrder.StartsWith("senderFirstName"))
                return x => x.SenderAccount.AspNetUser.FirstName;
            if (sortOrder.StartsWith("senderLastName"))
                return x => x.SenderAccount.AspNetUser.LastName;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("amount")) return x => x.Amount;
            return x => x.ValidFrom;
        }

        public IActionResult Create(string senderId){

            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateTransaction(null, 0, "", senderId, "", DateTime.Now.Date)));
        }


        public async Task<IActionResult> Details(string id) {
            var c = await transactions.GetObject(id);
            return View(TransactionViewFactory.Create(c));
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] TransactionView model){
            bool receiverExists = await checkIfReceiverAccountExists(model.ReceiverAccountId);

            if (receiverExists) {
                double amountD = Convert.ToDouble(model.Amount);

                var receiverObject = await accounts.GetObject(model.ReceiverAccountId);
                var senderObject = await accounts.GetObject(model.SenderAccountId);

                bool senderIsOk = validateSender(senderObject, amountD); //check if has enough balance and active card
                bool receiverIsOk = validateReceiver(receiverObject); //c

                if (senderIsOk && receiverIsOk) {
                    //receiverBalance
                    receiverObject.Data.Balance = receiverObject.Data.Balance + amountD;

                    //senderBalance
                    senderObject.Data.Balance = senderObject.Data.Balance - amountD;

                    //Transaction
                    model.ID = Guid.NewGuid().ToString();
                    var transaction = TransactionViewFactory.Create(model);
                    transaction.Data.Amount = amountD;
                    transaction.Data.ValidFrom = DateTime.Now;
                    transaction.Data.Explanation = model.Explanation;
                    transaction.Data.SenderAccountId = model.SenderAccountId;
                    transaction.Data.ReceiverAccountId = model.ReceiverAccountId;


                    await accounts.UpdateObject(senderObject);
                    await accounts.UpdateObject(receiverObject);
                    await transactions.AddObject(transaction);

                    ErrorMessage = "Transaction successfully done to " + model.ReceiverAccountId + " from " +
                                   model.SenderAccountId +
                                   " in the amount of " + amountD;
                }
            }
            return View("Info");
        }

        private async Task<bool> checkIfReceiverAccountExists(string rAccountId)
        {
            var o = await accounts.GetObject(rAccountId);
                if (o.Data.AspNetUserId != "Unspecified") //vb peab seda siin rohkem kontrollima
                {
                    return true;
                }
                   
                ErrorMessage = "Receiver account number doesn't exist in our system. Cannot make transaction!";
                return false;   
        }

        private bool validateReceiver(Account receiverObject) {
            string receiverCardStatus = receiverObject.Data.Status;

            if (receiverCardStatus == "Active") {
                return true;
            }

            ErrorMessage = "Receiver's card is not active. Cannot make transaction.";
            return false;
        }

        private bool validateSender(Account senderObject, double amount) {
            double? senderBalance = senderObject.Data.Balance;
            string senderCardStatus = senderObject.Data.Status;

            if (senderBalance >= amount) {
                if (senderCardStatus == "Active") {
                    return true;
                }

                ErrorMessage = "Your card is not active. Cannot make transaction.";
                return false;
            }

            ErrorMessage = "Your balance is " + senderBalance + " , but transaction amount is " 
            + amount + ". Cannot make transaction.";
            return false;
        }

        public object GetById(string id) {
            return transactions.GetObject(id);
        }
    }
}
