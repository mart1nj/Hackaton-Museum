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

        public async Task<IActionResult> ChangeSeenStatus(string notificationId, bool? seenStatus = null) {
            var notification = await notifications.GetObject(notificationId);
            switch (notification) {
                case WelcomeNotification wel:
                    var welcome =
                        NotificationFactory.CreateWelcomeNotification(wel.Data?.ID,
                            wel.Data?.SenderId, wel.Data?.ReceiverId, seenStatus ?? !wel.Data?.IsSeen,
                            wel.Data?.ValidFrom, wel.Data?.ValidTo);
                    await notifications.UpdateObject(welcome);
                    break;
                case NewTransactionNotification tra:
                    var transaction =
                        NotificationFactory.CreateNewTransactionNotification(tra.Data?.ID,
                            tra.Data?.SenderId, tra.Data?.ReceiverId, tra.Data?.Amount, seenStatus ?? !tra.Data?.IsSeen,
                            tra.Data?.ValidFrom, tra.Data?.ValidTo);
                    await notifications.UpdateObject(transaction);
                    break;
                case RequestStatusNotification reqStatus:
                    var requestStatus =
                        NotificationFactory.CreateRequestStatusNotification(reqStatus.Data?.ID,
                            reqStatus.Data?.SenderId, reqStatus.Data?.ReceiverId, reqStatus.Data?.Amount, reqStatus.Data?.Status ?? TransactionStatus.Pending,
                            seenStatus ?? !reqStatus.Data?.IsSeen, reqStatus.Data?.ValidFrom, reqStatus.Data?.ValidTo);
                    await notifications.UpdateObject(requestStatus);
                    break;
                case NewRequestTransactionNotification req:
                    var request =
                        NotificationFactory.CreateNewRequestTransactionNotification(req.Data?.ID,
                            req.Data?.SenderId, req.Data?.ReceiverId, req.Data?.Amount,
                            seenStatus ?? !req.Data?.IsSeen, req.Data?.ValidFrom, req.Data?.ValidTo);
                    await notifications.UpdateObject(request);
                    break;
                case NewInsuranceNotification ins:
                    var insurance =
                        NotificationFactory.CreateNewInsuranceNotification(
                            ins.Data?.ID, ins.Data?.SenderId, ins.Data?.ReceiverId, ins.Data?.InsuranceType,
                            seenStatus ??!ins.Data?.IsSeen, ins.Data?.ValidFrom, ins.Data?.ValidTo);
                    await notifications.UpdateObject(insurance);
                    break;
            }
            return new EmptyResult();
        }

        public async Task<IActionResult> ChangeSeenStatusToTrueForAll() {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return new EmptyResult();
            var notificationsList = await loadNotifications(loggedInUser);
            var id = "";
            foreach (var notification in notificationsList) {
                switch (notification) {
                    case WelcomeNotification wel:
                        id = wel.Data.ID;
                        break;
                    case NewTransactionNotification tra:
                        id = tra.Data.ID;
                        break;
                    case RequestStatusNotification reqStatus:
                        id = reqStatus.Data.ID;
                        break;
                    case NewRequestTransactionNotification req:
                        id = req.Data.ID;
                        break;
                    case NewInsuranceNotification ins:
                        id = ins.Data.ID;
                        break;
                }
                await ChangeSeenStatus(id, true);
            }
            return new EmptyResult();
        }       
        public async Task<IActionResult> Delete(string id)
        {
            var obj = await notifications.GetObject(id);
            await notifications.DeleteObject(obj);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ViewNotification(string notificationId)
        {
            var notification = await notifications.GetObject(notificationId);
            switch (notification)
            {
                case WelcomeNotification _:
                    return RedirectToAction("Index");
                case NewTransactionNotification tra:
                    return RedirectToAction("Index", "Transaction", new { id = tra.Data.ReceiverId });
                case RequestStatusNotification reqStatus:
                    return RedirectToAction("SentIndex", "RequestTransaction", new { id = reqStatus.Data.SenderId });
                case NewRequestTransactionNotification req:
                    return RedirectToAction("ReceivedIndex", "RequestTransaction", new { id = req.Data.ReceiverId });
                case NewInsuranceNotification _:
                    return RedirectToAction("Index", "Insurance");
            }
            return new EmptyResult();
        }

    }
}