using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Bank;
using Open.Data.Notification;
using Open.Domain.Bank;
using Open.Domain.Notification;
using Open.Facade.Bank;
using Open.Facade.Notification;
namespace Open.Sentry.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationsRepository notifications;
        private readonly IAccountsRepository accounts;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationsController(INotificationsRepository r, IAccountsRepository a,
        UserManager<ApplicationUser> uManager)
        {
            notifications = r;
            accounts = a;
            userManager = uManager;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortSenderAccount"] = sortOrder == "senderAccount" ? "senderAccount_desc" : "senderAccount";
            ViewData["SortMessage"] = sortOrder == "message" ? "message_desc" : "message";
            notifications.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            notifications.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            notifications.SearchString = searchString;
            notifications.PageIndex = page ?? 1;
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return View();
            var notificationsList = await loadNotifications(loggedInUser);
            var notificationsViewsList = new NotificationViewsList(notificationsList);
            foreach (var notification in notificationsViewsList) { await loadSender(notification); }
            return View(notificationsViewsList);
        }
        private async Task<PaginatedList<INotification>> loadNotifications(ApplicationUser loggedInUser) {
            var bankAccounts = await accounts.LoadAccountsForUser(loggedInUser.Id);
            var bankAccountsViewsList = new AccountsViewsList(bankAccounts);
            List<string> bankAccountIds = new List<string>();
            foreach (var account in bankAccountsViewsList) { bankAccountIds.Add(account.ID); }

            var notificationsList =
                await notifications.LoadNotificationsForAllUsers(bankAccountIds);
            return notificationsList;
        }
        private Func<NotificationData, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
            if (sortOrder.StartsWith("senderAccount")) return y => y.SenderId;
            if (sortOrder.StartsWith("message")) return x => x.Message;
            return x => x.ValidFrom;
        }
        private async Task loadSender(NotificationView notification)
        {
            notification.Sender =
                AccountViewFactory.Create(await accounts.GetObject(notification.SenderAccountId));
            notification.Sender.AspNetUser =
                await userManager.FindByIdAsync(notification.Sender.AspNetUserId);
        }

        public async Task<IActionResult> ChangeSeenStatus(string notificationId) {
            var notification = await notifications.GetObject(notificationId);
            switch (notification) {
                case WelcomeNotification wel:
                    WelcomeNotification welcome =
                        NotificationFactory.CreateWelcomeNotification(wel.Data?.ID,
                            wel.Data?.SenderId, wel.Data?.ReceiverId, !wel.Data?.IsSeen,
                            wel.Data?.ValidFrom, wel.Data?.ValidTo);
                    await notifications.UpdateObject(welcome);
                    break;
                case NewTransactionNotification tra:
                    NewTransactionNotification transaction =
                        NotificationFactory.CreateNewTransactionNotification(tra.Data?.ID,
                            tra.Data?.SenderId, tra.Data?.ReceiverId, tra.Data?.Amount, !tra.Data?.IsSeen,
                            tra.Data?.ValidFrom, tra.Data?.ValidTo);
                    await notifications.UpdateObject(transaction);
                    break;
                case NewRequestTransactionNotification req:
                    NewRequestTransactionNotification request =
                        NotificationFactory.CreateNewRequestTransactionNotification(req.Data?.ID,
                            req.Data?.SenderId, req.Data?.ReceiverId, req.Data?.Amount, req.Data?.Status ?? Status.Pending,
                            !req.Data?.IsSeen, req.Data?.ValidFrom, req.Data?.ValidTo);
                    await notifications.UpdateObject(request);
                    break;
            }
            return new EmptyResult();
        }

        public async Task<IActionResult> ChangeSeenStatusForAll() {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return new EmptyResult();
            var notificationsList = await loadNotifications(loggedInUser);
            foreach (var notification in notificationsList) {
                switch (notification) {
                    case WelcomeNotification wel:
                        WelcomeNotification welcome =
                            NotificationFactory.CreateWelcomeNotification(wel.Data?.ID,
                                wel.Data?.SenderId, wel.Data?.ReceiverId, true,
                                wel.Data?.ValidFrom, wel.Data?.ValidTo);
                        await notifications.UpdateObject(welcome);
                        break;
                    case NewTransactionNotification tra:
                        NewTransactionNotification transaction =
                            NotificationFactory.CreateNewTransactionNotification(tra.Data?.ID,
                                tra.Data?.SenderId, tra.Data?.ReceiverId, tra.Data?.Amount,
                                true,
                                tra.Data?.ValidFrom, tra.Data?.ValidTo);
                        await notifications.UpdateObject(transaction);
                        break;
                    case NewRequestTransactionNotification req:
                        NewRequestTransactionNotification request =
                            NotificationFactory.CreateNewRequestTransactionNotification(
                                req.Data?.ID,
                                req.Data?.SenderId, req.Data?.ReceiverId, req.Data?.Amount,
                                req.Data?.Status ?? Status.Pending,
                                true, req.Data?.ValidFrom, req.Data?.ValidTo);
                        await notifications.UpdateObject(request);
                        break;
                }
            }
            return new EmptyResult();
        }
    }
}