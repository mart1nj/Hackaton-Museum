using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Domain.Notification;
using Open.Facade.Bank;
using Open.Sentry.Hubs;

namespace Open.Sentry.Controllers {
    public class BankAccountController : Controller {
        private readonly IAccountsRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationsRepository notifications;
        private readonly IHubContext<BankHub> _bankHub;
        internal const string properties = "ID, ValidFrom, ValidTo, Balance, Type, Status, AspNetUserId";

        public BankAccountController(IAccountsRepository r, UserManager<ApplicationUser> uManager,
            INotificationsRepository n, IHubContext<BankHub> bankHub) {
            repository = r;
            userManager = uManager;
            notifications = n;
            _bankHub = bankHub;
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] AccountView c) {
            c.ID = BankId.NewBankId();
            await validateId(c.ID, ModelState);
            if (!ModelState.IsValid) return View(c);
            c.Balance = 0;
            c.Status = "Active";
            c.Type = Enum.GetName(typeof(CardType), int.Parse(c.Type));
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            c.AspNetUserId = loggedInUser.Id;
            var o = AccountFactory.CreateAccount(c.ID, c.Balance, c.Type, c.Status, c.AspNetUserId,
                c.ValidFrom = DateTime.Now, c.ValidTo = DateTime.Now.AddYears(2));
            await repository.AddObject(o);
            await _bankHub.Clients.All.SendAsync("NewAccount", c.ID, c.Type, c.Balance, c.Status);
            await createWelcomeNotification(c.ID);
            return RedirectToAction("Index", "Home");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id) {
            return (await repository.GetObject(id))?.Data?.ID == id;
        }

        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<AccountView>(c => c.ID);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }

        private async Task createWelcomeNotification(string accountId) {
            var welcome = NotificationFactory.CreateWelcomeNotification(Guid.NewGuid().ToString(), "systemAccount",
                accountId, false, DateTime.Now);
            await notifications.AddObject(welcome);
        }
    }
}
