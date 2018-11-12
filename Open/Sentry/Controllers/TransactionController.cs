using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
using SortOrder = Open.Core.SortOrder;

namespace Open.Sentry.Controllers {
    [Authorize]
    public class TransactionController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly ITransactionRepository transactions;
        private readonly UserManager<ApplicationUser> userManager;
        public static Account BankAccount;
        private IConfiguration configuration;

        internal const string properties =
            "ID, Amount, Explanation, ReceiverAccountId, SenderAccountId," +
            "ValidFrom";

        public static int Error = 0;
        public static string ErrorMessage;

        public TransactionController(ITransactionRepository p, IAccountsRepository a,
            UserManager<ApplicationUser> uManager) {
            transactions = p;
            accounts = a;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string id, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortSenderFirstName"] =
                sortOrder == "senderFirstName" ? "senderFirstName_desc" : "senderFirstName";
            ViewData["SortSenderLastName"] = sortOrder == "senderLastName" ? "senderLastName_desc" : "senderLastName";
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            transactions.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? Core.SortOrder.Descending
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

                if (transaction.SenderAccount.AspNetUserId == appUser.Id) {
                    transaction.Amount = -transaction.Amount;
                    var receiver = transaction.SenderAccount;
                    var receiverId = transaction.SenderAccountId;
                    transaction.SenderAccount = transaction.ReceiverAccount;
                    transaction.ReceiverAccount = receiver;
                    transaction.SenderAccountId = transaction.ReceiverAccountId;
                    transaction.ReceiverAccountId = receiverId;
                }
            }

            return View(viewList);
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

        public async Task<IActionResult> Create(string senderId) {
            // var l = await transactions.LoadTransactionsForAccount(senderId);
            //return View("Create");
            // BankAccount = await accounts.GetObject(senderId);
            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateTransaction(null, null, "", senderId, "", DateTime.Now.Date)));
        }


        public async Task<IActionResult> Details(string id) {
            var c = await transactions.GetObject(id);
            return View(TransactionViewFactory.Create(c));
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] TransactionView model) {
            if (!ModelState.IsValid) return View(model);
            //double amountD = 0;
            string rAccountId = model.ReceiverAccountId;
            string sAccountId = model.SenderAccountId;
            string explanation = model.Explanation;

            bool receiverExists = checkIfReceiverAccountExists(rAccountId);

            if (receiverExists) {
                double amountD = Convert.ToDouble(model.Amount);

                var receiverObject = await accounts.GetObject(rAccountId);
                var senderObject = await accounts.GetObject(sAccountId);

                bool senderIsOk = validateSender(senderObject); //check if has enough balance and active card
                bool receiverIsOk = validateReceiver(receiverObject); //c

                if (senderIsOk && receiverIsOk) {
                    DateTime date = DateTime.Now;
                    //receiverBalance
                    receiverObject.Data.Balance = receiverObject.Data.Balance + amountD;

                    //senderBalance
                    senderObject.Data.Balance = senderObject.Data.Balance - amountD;

                    //senderTransaction
                    model.ID = Guid.NewGuid().ToString();
                    var senderTransaction = TransactionViewFactory.Create(model);
                    senderTransaction.Data.Amount = amountD * -1;
                    senderTransaction.Data.ValidFrom = date;
                    senderTransaction.Data.Explanation = explanation;
                    senderTransaction.Data.SenderAccountId = sAccountId;
                    senderTransaction.Data.ReceiverAccountId = rAccountId;
                    senderTransaction.Data.ReceiverAccount = null;

                    //receiverTransaction
                    model.ID = Guid.NewGuid().ToString();
                    var receiverTransaction = TransactionViewFactory.Create(model);
                    receiverTransaction.Data.Amount = amountD;
                    receiverTransaction.Data.ValidFrom = date;
                    receiverTransaction.Data.Explanation = explanation;
                    receiverTransaction.Data.SenderAccountId = rAccountId;
                    receiverTransaction.Data.ReceiverAccountId = sAccountId;
                    receiverTransaction.Data.ReceiverAccount = null;


                    await accounts.UpdateObject(senderObject);
                    await accounts.UpdateObject(receiverObject);
                    await transactions.AddObject(senderTransaction);
                    await transactions.AddObject(receiverTransaction);
                }
            }

            return RedirectToAction("Create");
        }

        private bool checkIfReceiverAccountExists(string rAccountId) {
            if (accounts.GetObject(rAccountId) != null) {
                return true;
            } else {
                Error = 1;
                ErrorMessage = "Receiver account number doesn't exist in our system. Cannot make transaction!";
                return false;
            }
        }

        private bool validateReceiver(Account receiverObject) {
            string receiverCardStatus = receiverObject.Data.Status;

            if (receiverCardStatus == "Active") {
                return true;
            }

            Error = 1;
            ErrorMessage = "Receiver's card is not active. Cannot make transaction.";
            return false;
        }

        private bool validateSender(Account senderObject) {
            double? senderBalance = senderObject.Data.Balance;
            string senderCardStatus = senderObject.Data.Status;

            if (senderBalance > 0) {
                if (senderCardStatus == "Active") {
                    return true;
                }

                Error = 1;
                ErrorMessage = "Your card is not active. Cannot make transaction.";
                return false;
            }

            Error = 1;
            ErrorMessage = "Your balance is " + senderBalance + ". Cannot make transaction.";
            return false;
        }

        public Object GetById(string id) {
            return transactions.GetObject(id);
        }
    }
}
