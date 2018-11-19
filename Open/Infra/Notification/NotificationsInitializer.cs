using System;
using System.Linq;
using Open.Data.Notification;
namespace Open.Infra.Notification
{
    public static class NotificationsInitializer
    {
        public static void Initialize(ApplicationDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Notifications.Any()) return;
            foreach (var account in c.Accounts) { initNotification(c, account.ID); }
            c.SaveChanges();
        }

        private static void initNotification(ApplicationDbContext c, string id) {
            if (id == "systemAccount") return;
            c.Notifications.Add(new WelcomeNotificationData { ID = Guid.NewGuid().ToString(), ReceiverId = id, SenderId = "systemAccount", ValidFrom = DateTime.Now});
        }
    }
}


