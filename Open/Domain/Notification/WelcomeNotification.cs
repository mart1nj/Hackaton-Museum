using Open.Data.Notification;
namespace Open.Domain.Notification
{

    public sealed class WelcomeNotification : Notification<WelcomeNotificationData>
    {
        public WelcomeNotification(WelcomeNotificationData r) : base(r ?? new WelcomeNotificationData()) { }
    }
}


