using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Notification;
namespace Open.Sentry.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationsRepository repository;

        public NotificationsController(INotificationsRepository r)
        {
            repository = r;
        }

    /*    public IActionResult Index()
        {
            return View();
        }*/

        public async Task ChangeSeenStatus(string id) {
            try {
                var notification = await repository.GetObject(id);
                switch (notification) {
                    case WelcomeNotification wel:
                        WelcomeNotification welcome =
                            NotificationFactory.CreateWelcomeNotification(wel.Data?.ID,
                                wel.Data?.SenderId, wel.Data?.ReceiverId, !wel.Data?.IsSeen,
                                wel.Data?.ValidFrom, wel.Data?.ValidTo);
                        await repository.UpdateObject(welcome);
                        break;
                }

                await repository.UpdateObject(notification);
            }
            catch { RedirectToAction("Index", "Home"); }
        }
    }
}