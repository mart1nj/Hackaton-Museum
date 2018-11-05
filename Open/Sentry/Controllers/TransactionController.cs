using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;

namespace Open.Sentry.Controllers
{
    [Authorize]
    public class TransactionController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly ITransactionRepository transactions;
        private readonly UserManager<ApplicationUser> userManager;

        internal const string properties =
            "ID, Amount, Explanation, ReceiverAccountId, SenderAccountId," +
            "ValidFrom";

        public static int Error = 0;
        public static string ErrorMessage;

        public TransactionController(ITransactionRepository p, IAccountsRepository a, UserManager<ApplicationUser> uManager)
        {
            transactions = p;
            accounts = a;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string id, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortSenderFirstName"] = sortOrder == "senderFirstName" ? "senderFirstName_desc" : "senderFirstName";
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
            var l = await transactions.LoadTransactionsForAccount(id);
            var viewList = new TransactionViewsList(l);
            var appUser = await userManager.GetUserAsync(HttpContext.User);
            foreach (var transaction in viewList)
            {
                transaction.SenderAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.SenderAccountId));
                transaction.SenderAccount.AspnetUser = await userManager.FindByIdAsync(transaction.SenderAccount.AspnetUserId);
                transaction.ReceiverAccount =
                    AccountViewFactory.Create(await accounts.GetObject(transaction.ReceiverAccountId));
                transaction.ReceiverAccount.AspnetUser = await userManager.FindByIdAsync(transaction.ReceiverAccount.AspnetUserId);

                if (transaction.SenderAccount.AspnetUserId == appUser.Id) 
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
            return View(viewList);
        }

        private Func<TransactionData, object> getSortFunction(string sortOrder)
        {
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] TransactionView c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            var o = TransactionViewFactory.Create(c);
            await transactions.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var c = await transactions.GetObject(id);
            return View(TransactionViewFactory.Create(c));
        }

       public async Task<IActionResult> makeTransaction(TransactionView model)
        {
            double amountD = 0;
            string rAccountId = model.ReceiverAccountId;
            string sAccountId = model.SenderAccountId;
            string explanation = model.Explanation;


           bool receiverExists = checkIfReceiverAccountExists(rAccountId);

            if (receiverExists)
            {
                try
                {
                    amountD = Convert.ToDouble(model.Amount);
                    var receiverObject = await accounts.GetObject(rAccountId);
                    var senderObject = await accounts.GetObject(sAccountId);

                    bool senderIsOk = validateSender(senderObject); //check if has enough balance and active card
                    bool receiverIsOk = validateReceiver(receiverObject); //check if exists and active card

                    if (senderIsOk && receiverIsOk)
                    {
                        subtractFromSenderAccount(senderObject, amountD);
                        addToReceiverAccount(receiverObject, amountD);
                        makeDatabaseChanges(senderObject, receiverObject, amountD, explanation);
                    }
                  
                }
                catch
                {
                    Error = 1;
                    ErrorMessage = "Amount is not in the correct format!";
                }
            }
            return View();
        }

        private void makeDatabaseChanges(Account senderObject, Account receiverObject, double amountD, string explanation)
        {
            using (SqlConnection sqlConnection = new SqlConnection("DefaultConnection"))
            {
                string receiverBalancequery = "UPDATE Account(Balance) VALUES (@rBalance) WHERE ID = @rId";
                string senderBalancequery = "UPDATE Account(Balance) VALUES (@sBalance) WHERE ID = @sId";
                string senderTransactionquery = "INSERT INTO Transactions(ValidFrom, ID, Amount, Explanation, SenderAccount, ReceiverAccount) VALUES (@ValidFrom, @ID, @Amount, @Explanation, @SenderAccount, @ReceiverAccount)";
                string receiverTransactionquery = "INSERT INTO Transactions(ValidFrom, ID, Amount, Explanation, SenderAccount, ReceiverAccount) VALUES (@ValidFrom, @ID, @Amount, @Explanation, @SenderAccount, @ReceiverAccount)";

                SqlCommand sqlChangeReceiverBalance = new SqlCommand(receiverBalancequery, sqlConnection);
                SqlCommand sqlChangeSenderBalance = new SqlCommand(senderBalancequery, sqlConnection);
                SqlCommand sqlAddReceiverTransaction = new SqlCommand(senderTransactionquery, sqlConnection);
                SqlCommand sqlAddSenderTransaction = new SqlCommand(receiverTransactionquery, sqlConnection);


                sqlChangeReceiverBalance.Parameters.AddWithValue("@rBalance", senderObject.Data.Balance + amountD);
                sqlChangeReceiverBalance.Parameters.AddWithValue("@rId", senderObject.Data.ID);


                sqlChangeSenderBalance.Parameters.AddWithValue("@sBalance", senderObject.Data.Balance - amountD);
                sqlChangeSenderBalance.Parameters.AddWithValue("@sId", senderObject.Data.ID);

                string transactionId = Guid.NewGuid().ToString();
                DateTime date = DateTime.Now;
                sqlAddReceiverTransaction.Parameters.AddWithValue("@ValidFrom", date);
                sqlAddReceiverTransaction.Parameters.AddWithValue("@ID",transactionId);
                sqlAddReceiverTransaction.Parameters.AddWithValue("@Explanation", explanation);
                sqlAddReceiverTransaction.Parameters.AddWithValue("@Amount", amountD * (-1));
                sqlAddReceiverTransaction.Parameters.AddWithValue("@SenderAccount", senderObject.Data.ID);
                sqlAddReceiverTransaction.Parameters.AddWithValue("@ReceiverAccount", receiverObject.Data.ID);


                sqlAddSenderTransaction.Parameters.AddWithValue("@ValidFrom", date);
                sqlAddSenderTransaction.Parameters.AddWithValue("@ID", transactionId);
                sqlAddSenderTransaction.Parameters.AddWithValue("@Explanation", explanation);
                sqlAddSenderTransaction.Parameters.AddWithValue("@Amount", amountD);
                sqlAddSenderTransaction.Parameters.AddWithValue("@SenderAccount", receiverObject.Data.ID);
                sqlAddSenderTransaction.Parameters.AddWithValue("@ReceiverAccount", senderObject.Data.ID);

                sqlConnection.Open();
                sqlChangeSenderBalance.ExecuteNonQuery();
                sqlChangeReceiverBalance.ExecuteNonQuery();
                sqlAddReceiverTransaction.ExecuteNonQuery();
                sqlAddSenderTransaction.ExecuteNonQuery();
            }
        }

        private void addToReceiverAccount(Account receiverObject, double amountD)
        {
            receiverObject.Data.Balance = receiverObject.Data.Balance + amountD;
        }

        private void subtractFromSenderAccount(Account senderObject, double amountD)
        {
            senderObject.Data.Balance = senderObject.Data.Balance - amountD;
        }

        private bool checkIfReceiverAccountExists(string rAccountId)
        {
            if (accounts.GetObject(rAccountId) != null)
            {
                return true;
            }
            else
            {
                Error = 1;
                ErrorMessage = "Receiver account number doesn't exist in our system. Cannot make transaction!";
                return false;
            }
        }

        private bool validateReceiver(Account receiverObject)
        {
            string receiverCardStatus = receiverObject.Data.Status;
            string receiverId = receiverObject.Data.ID;


            if (receiverCardStatus == "Active")
            {
                return true;
            }
            else
            {
                Error = 1;
                ErrorMessage = "Receiver's card is not active. Cannot make transaction.";
                return false;
            }
        }

        private bool validateSender(Account senderObject)
        {
            double? senderBalance = senderObject.Data.Balance;
            string senderCardStatus = senderObject.Data.Status;

            if (senderBalance > 0)
            {
                if (senderCardStatus == "Active")
                {
                    return true;
                }
                else
                {
                    Error = 1;
                    ErrorMessage = "Your card is not active. Cannot make transaction.";
                    return false;
                }
            }
            else
            {
                Error = 1;
                ErrorMessage = "Your balance is " + senderBalance + ". Cannot make transaction.";
                return false;
            }
        }
    }
}
