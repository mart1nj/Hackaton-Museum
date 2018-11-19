using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Domain.Notification;
using Open.Facade.Bank;
using Open.Facade.Notification;

namespace Open.Sentry.Extensions {
    public class NotificationsViewComponent : ViewComponent {
        private readonly IAccountsRepository accounts;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationsRepository notifications;
        public NotificationsViewComponent(IAccountsRepository a,
            UserManager<ApplicationUser> uManager,
            INotificationsRepository n) {
            accounts = a;
            userManager = uManager;
            notifications = n;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return View();
            var bankAccounts = await accounts.LoadAccountsForUser(loggedInUser.Id);
            var bankAccountsViewsList = new AccountsViewsList(bankAccounts);
            List<string> bankAccountIds = new List<string>();
            foreach (var account in bankAccountsViewsList) { bankAccountIds.Add(account.ID); }
            var notificationsList =
                await notifications.LoadNotificationsForAllUsers(bankAccountIds);
            var notificationsViewsList = new NotificationViewsList(notificationsList);
            foreach (var notification in notificationsViewsList) {
                notification.Sender = AccountViewFactory.Create(await accounts.GetObject(notification.SenderAccountId));
                notification.Sender.AspNetUser =
                    await userManager.FindByIdAsync(notification.Sender.AspNetUserId);
                notification.Receiver = AccountViewFactory.Create(await accounts.GetObject(notification.ReceiverAccountId));
                notification.Receiver.AspNetUser =
                    await userManager.FindByIdAsync(notification.Receiver.AspNetUserId);
            }
            return View(notificationsViewsList);
        }
    }
}