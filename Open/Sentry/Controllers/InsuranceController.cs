using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
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
        internal const string properties =
            "ID, PaymentInStringFormat, Type, Status, AccountId, ValidFrom, ValidTo";

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
            ViewData["SortAccountId"] = sortOrder == "accountId" ? "accountId_desc" : "accountId";
            ViewData["SortValidTo"] = string.IsNullOrEmpty(sortOrder) ? "validTo_desc" : "";
            ViewData["SortStatus"] = sortOrder == "status" ? "status_desc" : "status";            
            insurances.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            
            
            insurances.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            insurances.SearchString = searchString;
            insurances.PageIndex = page ?? 1;
            
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return View();
            var bankAccounts = await accounts.LoadAccountsForUser(loggedInUser.Id);
            var bankAccountsViewsList = new AccountsViewsList(bankAccounts);
            List<string> bankAccountIds = new List<string>();
            foreach (var account in bankAccountsViewsList) { bankAccountIds.Add(account.ID); }
            var insuranceList =
                await insurances.LoadInsurancesForUser(bankAccountIds);
            var insurancesViewsList = new InsuranceViewsList(insuranceList);
            return View(insurancesViewsList);
        }
       
       public IActionResult Create(string accountId){        
           return View(InsuranceViewFactory.Create(
               InsuranceFactory.CreateInsurance(null, null, "", "", accountId)));
       }

       [HttpPost]
       public async Task<IActionResult> Create([Bind(properties)] InsuranceView model)
       {
          //if (!ModelState.IsValid) return View(model);
           var accountObject = await accounts.GetObject(model.AccountId);         
           bool isAccountOk = checkIfHasEnoughPaymentMoney(accountObject, model.Payment);
           bool isInsuranceDataOk = checkIfIsntInPast(model.ValidFrom, model.ValidTo);
           
           if (isAccountOk && isInsuranceDataOk){
               model.ID = Guid.NewGuid().ToString();
               var insurance = InsuranceViewFactory.Create(model);
               insurance.Data.Payment = model.Payment;
               insurance.Data.Type = Enum.GetName(typeof(InsuranceType), int.Parse(model.Type));
               insurance.Data.ValidFrom = model.ValidFrom ?? DateTime.MinValue;
               insurance.Data.ValidTo = model.ValidTo ?? DateTime.MaxValue;
               insurance.Data.AccountId = model.AccountId;
               insurance.Data.Status = "Active";

               accountObject.Data.Balance = accountObject.Data.Balance - model.Payment;

               await insurances.AddObject(insurance);
               await accounts.UpdateObject(accountObject);
               await generateInsuranceNotification(insurance);
               
               TempData["Status"] =                  
                   insurance.Data.Type +  " insurance is now valid from " + insurance.Data.ValidFrom.ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " to "
                   + insurance.Data.ValidTo.ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " in payment of " +  insurance.Data.Payment;
           }

           return RedirectToAction("Index");
       }

       private bool checkIfIsntInPast(DateTime? modelValidFrom, DateTime? modelValidTo)
       {         
           DateTime yesterday = DateTime.Now.AddDays(-1);

           if (modelValidFrom > yesterday && modelValidTo >= DateTime.Now)
           {
               return true;
           }

           TempData["Status"] = "Dates cannot be in the past.";
           return false; 
       }

       private bool checkIfHasEnoughPaymentMoney(Account account, decimal? payment)
       {
           decimal? balance = account.Data.Balance;

           if (balance >= payment)
           {
               return true;
           }

           TempData["Status"] = "Your balance " + balance + " is smaller than payment amount " + payment + ". Cannot make insurance";
           return false;
       }
       
       private Func<InsuranceData, object> getSortFunction(string sortOrder) {
           if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
           if (sortOrder.StartsWith("ValidTo")) return x => x.ValidTo;
           if (sortOrder.StartsWith("AccountId")) return x => x.AccountId;
           if (sortOrder.StartsWith("Type")) return x => x.Type;
           if (sortOrder.StartsWith("Status")) return x => x.Status;
           if (sortOrder.StartsWith("Payment")) return x => x.Payment;
           return x => x.ValidFrom;

       }
       
       private async Task generateInsuranceNotification(Insurance insurance)
       {
           var notification = NotificationFactory.CreateNewInsuranceNotification(
               Guid.NewGuid().ToString(), "systemAccount", insurance.Data.AccountId,
               insurance.Data.Type, false, insurance.Data.ValidFrom, insurance.Data.ValidTo);
           await notifications.AddObject(notification);
       }

   }
}
