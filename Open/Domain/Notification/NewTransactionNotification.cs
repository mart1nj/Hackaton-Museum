using Open.Data.Notification;
namespace Open.Domain.Notification
{

    public sealed class NewTransactionNotification : Notification<NewTransactionNotificationData>
    {
        public NewTransactionNotification(NewTransactionNotificationData r) : base(r ?? new NewTransactionNotificationData()) { }
    }
}


