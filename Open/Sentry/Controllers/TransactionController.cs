using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Bank;
using Open.Data.Quantity;
using Open.Domain.Bank;
using Open.Domain.Quantity;
using Open.Facade.Bank;
using Open.Facade.Quantity;
using StackExchange.Redis;

namespace Open.Sentry.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository transactions;
        private readonly ICurrencyRepository currencyes;
        private readonly IPaymentMethodsRepository paymentMethods;
        internal const string properties = "ID, Amount, CurrencyID, PaymentMethodID, DateDue, DateMade, ValidTo";

        public TransactionController(ITransactionRepository p, ICurrencyRepository c,
            IPaymentMethodsRepository m)
        {
            transactions = p;
            currencyes = c;
            paymentMethods = m;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["SortMethod"] = sortOrder == "method" ? "method_desc" : "method";
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
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.DateMade;
            if (sortOrder.StartsWith("validFrom")) return x => x.DateMade;
            if (sortOrder.StartsWith("amount")) return x => x.Amount;
            if (sortOrder.StartsWith("method")) return x => x.PaymentMethod;
            return x => x.DateMade;
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
