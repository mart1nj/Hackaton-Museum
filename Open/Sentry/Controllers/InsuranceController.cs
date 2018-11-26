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
namespace Open.Sentry.Controllers
{
   [Authorize]
    public class InsuranceController : Controller {
        private readonly IAccountsRepository accounts;
       private readonly IInsuranceRepository insurances;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationsRepository notifications;
       public static Account BankAccount;

        internal const string properties =
            "ID, PaymentInString, Type, Status, AccountId, ValidFrom, ValidTo";

        public static string ErrorMessage;

        public InsuranceController(IInsuranceRepository p, IAccountsRepository a, INotificationsRepository n,
            UserManager<ApplicationUser> uManager) {
            insurances = p;
            accounts = a;
            notifications = n;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string id, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null){
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortType"] = sortOrder == "type" ? "type_desc" : "type";
            ViewData["SortPayment"] = sortOrder == "payment" ? "payment_desc" : "payment";
            ViewData["SortValidTo"] = string.IsNullOrEmpty(sortOrder) ? "validTo_desc" : "";
            ViewData["SortStatus"] = sortOrder == "status" ? "status_desc" : "status";
            
            
            insurances.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            insurances.SearchString = searchString;
            insurances.PageIndex = page ?? 1;
            BankAccount = await accounts.GetObject(id);

            var l = await insurances.LoadInsurancesForUser(id);
            var viewList = new InsuranceViewsList(l);
            return View(viewList);
        }
       
       public IActionResult Create(string accountId){        
           return View(InsuranceViewFactory.Create(
               InsuranceFactory.CreateInsurance(null, null, "", "", accountId, null, null)));
       }

      /* [HttpPost]
       public async Task<IActionResult> Create([Bind(properties)] TransactionView model)
       {
       }*/


   }
}
