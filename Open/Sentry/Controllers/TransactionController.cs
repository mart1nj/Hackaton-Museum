using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;

namespace Open.Sentry.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository transactions;
        internal const string properties =
            "ID, Amount, Explanation, ReceiverAccountId, SenderAccountId," +
            "ValidFrom";

        public TransactionController(ITransactionRepository p)
        {
            transactions = p;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
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
            var l = await transactions.GetObjectsList();
            return View(new TransactionViewsList(l));
        }

        private Func<TransactionData, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
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
