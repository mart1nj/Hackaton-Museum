using Open.Data.Notification;
namespace Open.Domain.Notification
{

    public sealed class NewRequestTransactionNotification : Notification<NewRequestTransactionNotificationData>
    {
        public NewRequestTransactionNotification(NewRequestTransactionNotificationData r) : base(r ?? new NewRequestTransactionNotificationData()) { }
    }
}


