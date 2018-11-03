using System;
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
                ? SortOrder.Descending
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
    }
}
