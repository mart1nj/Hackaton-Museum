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
    [Authorize] public class RequestTransactionController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly IRequestTransactionRepository requests;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationsRepository notifications;

        internal const string properties =
            "ID, AmountInStringFormat, Explanation, ReceiverAccountId, SenderAccountId, Status, ValidFrom";

        public RequestTransactionController(IRequestTransactionRepository r, IAccountsRepository a,
            INotificationsRepository n,
            UserManager<ApplicationUser> uManager) {
            requests = r;
            accounts = a;
            notifications = n;
            userManager = uManager;
        }

        public async Task<IActionResult> SentIndex(string id, string sortOrder = null,
            string currentFilter = null,
            string searchString = null, int? page = null) {
            paginate(id, sortOrder, currentFilter, searchString, page);
            var bankAccount = await accounts.GetObject(id);
            ViewBag.BankAccountID = bankAccount.Data.ID;
            var l = await requests.LoadSentRequestsForAccount(id);
            var viewList = new RequestTransactionViewsList(l);
            await loadSenderAndReceiver(viewList);
            return View(viewList);
        }
        public async Task<IActionResult> ReceivedIndex(string id, string sortOrder = null,
            string currentFilter = null,
            string searchString = null, int? page = null)
        {
            paginate(id, sortOrder, currentFilter, searchString, page);
            var bankAccount = await accounts.GetObject(id);
            ViewBag.BankAccountID = bankAccount.Data.ID;
            var l = await requests.LoadReceivedRequestsForAccount(id);
            var viewList = new RequestTransactionViewsList(l);
            await loadSenderAndReceiver(viewList);
            return View(viewList);
        }
        private void paginate(string id, string sortOrder, string currentFilter, string searchString,
            int? page) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortValidFrom"] = string.IsNullOrEmpty(sortOrder) ? "validFrom_desc" : "";
            ViewData["SortSenderAccount"] =
                sortOrder == "senderAccount" ? "senderAccount_desc" : "senderAccount";
            ViewData["SortExplanation"] =
                sortOrder == "explanation" ? "explanation_desc" : "explanation";
            ViewData["SortAmount"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["SortStatus"] = sortOrder == "status" ? "status_desc" : "status";
            requests.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            requests.SortFunction = getSortFunction(sortOrder, id);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            requests.SearchString = searchString;
            requests.PageIndex = page ?? 1;
        }
        private async Task loadSenderAndReceiver(RequestTransactionViewsList viewList) {
            foreach (var request in viewList) {
                request.SenderAccount =
                    AccountViewFactory.Create(await accounts.GetObject(request.SenderAccountId));
                request.SenderAccount.AspNetUser =
                    await userManager.FindByIdAsync(request.SenderAccount.AspNetUserId);
                request.ReceiverAccount =
                    AccountViewFactory.Create(await accounts.GetObject(request.ReceiverAccountId));
                request.ReceiverAccount.AspNetUser =
                    await userManager.FindByIdAsync(request.ReceiverAccount.AspNetUserId);
            }
        }
        private Func<RequestTransactionData, object> getSortFunction(string sortOrder,
            string accountId) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ValidFrom;
            if (sortOrder.StartsWith("receiverAccount"))
                return y => y.SenderAccountId == accountId
                    ? y.ReceiverAccountId
                    : y.SenderAccountId;
            if (sortOrder.StartsWith("explanation")) return x => x.Explanation;
            if (sortOrder.StartsWith("status")) return x => x.Status;
            if (sortOrder.StartsWith("amount"))
                return y => y.SenderAccountId == accountId
                    ? -y.Amount
                    : y.Amount;
            return x => x.ValidFrom;
        }

        public IActionResult Create(string receiverId) {
            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateRequest(null, 0, "", "", receiverId,
                    TransactionStatus.Pending, DateTime.Now)));
        }

        public IActionResult CreateWithSender(string receiverId, string senderId) {
            return View(TransactionViewFactory.Create(
                TransactionFactory.CreateRequest(null, 0, "", senderId, receiverId,
                    TransactionStatus.Pending, DateTime.Now)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] RequestTransactionView model) {
            bool senderExists = await checkIfSenderAccountExists(model.SenderAccountId);

            if (senderExists) {
                var receiverObject = await accounts.GetObject(model.ReceiverAccountId);
                var senderObject = await accounts.GetObject(model.SenderAccountId);
                bool senderIsOk = validateReceiverAndSender(receiverObject, senderObject);
                bool receiverIsOk = validateReceiver(receiverObject);

                if (senderIsOk && receiverIsOk) {
                    model.ID = Guid.NewGuid().ToString();
                    var request = TransactionFactory.CreateRequest(model.ID, model.Amount,
                        model.Explanation, model.SenderAccountId, model.ReceiverAccountId,
                        TransactionStatus.Pending, DateTime.Now, model.ValidTo);
                    await requests.AddObject(request);
                    await generateRequestNotification(request);
                    TempData["TransactionStatus"] =
                        "Request successfully done to " + model.ReceiverAccountId + " from " +
                        model.SenderAccountId +
                        " in the amount of " + model.Amount + ". ";
                }
            }

            return RedirectToAction("SentIndex", new {id = model.ReceiverAccountId});
        }
        private async Task generateRequestNotification(RequestTransaction request) {
            var notification = NotificationFactory.CreateNewRequestTransactionNotification(
                Guid.NewGuid().ToString(), request.Data.ReceiverAccountId,
                request.Data.SenderAccountId, request.Data.Amount,
                false, DateTime.Now);
            await notifications.AddObject(notification);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWithReceiver(
            [Bind(properties)] RequestTransactionView model) {
            return await Create(model);
        }

        private async Task<bool> checkIfSenderAccountExists(string sAccountId) {
            var o = await accounts.GetObject(sAccountId);
            if (o.Data.AspNetUserId != "Unspecified") //vb peab seda siin rohkem kontrollima
            {
                return true;
            }

            TempData["TransactionStatus"] =
                "Account number does not exist in our system. Cannot request transaction!";
            return false;
        }

        private bool validateReceiverAndSender(Account receiverObject, Account senderObject) {
            string senderCardStatus = senderObject.Data.Status;

            if (senderCardStatus == "Active") {
                if (senderObject.Data.ID != receiverObject.Data.ID) { return true; }

                TempData["TransactionStatus"] = "You cannot request a transaction to yourself.";
                return false;
            }

            TempData["TransactionStatus"] =
                "Sender's card is not active. Cannot request transaction.";
            return false;
        }
        private bool validateReceiver(Account receiverObject) {
            string senderCardStatus = receiverObject.Data.Status;
            if (senderCardStatus == "Active") { return true; }

            TempData["TransactionStatus"] = "Your card is not active. Cannot request transaction.";
            return false;
        }

        public object GetById(string id) {
            return requests.GetObject(id);
        }

        public async Task<IActionResult> ConfirmRequest(string id)
        {
            var request = await requests.GetObject(id);
            return RedirectToAction("CreateRequested", "Transaction", new { amount = request.Data.Amount, explanation = request.Data.Explanation,
                senderAccountId = request.Data.SenderAccountId, receiverAccountId = request.Data.ReceiverAccountId
            });
        }

        public async Task<IActionResult> DenyRequest(string id)
        {
            var request = await requests.GetObject(id);
            request.Data.Status = TransactionStatus.Denied;
            await requests.UpdateObject(request);
            await generateStatusNotification(request, TransactionStatus.Denied);
            return RedirectToAction("ReceivedIndex", new { id = request.Data.SenderAccountId });
        }
        private async Task generateStatusNotification(RequestTransaction request, TransactionStatus status)
        {
            var notification = NotificationFactory.CreateRequestStatusNotification(
                Guid.NewGuid().ToString(), request.Data.SenderAccountId,
                request.Data.ReceiverAccountId, request.Data.Amount, status,
                false, DateTime.Now);
            await notifications.AddObject(notification);
        }
    }
}
