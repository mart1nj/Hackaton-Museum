using Open.Core;
namespace Open.Facade.Notification
{
    public class RequestStatusNotificationView : NewRequestTransactionNotificationView
    {
        public TransactionStatus Status { get; set; }
    }
}
