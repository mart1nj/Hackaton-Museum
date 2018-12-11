using Open.Core;
namespace Open.Data.Notification
{
    public class RequestStatusNotificationData : NewRequestTransactionNotificationData
    {
        public override string Message
        {
            get => getString(ref message,
                $"has {Status.ToString().ToLower()} your request for a transaction in the amount of");
            set => message = value;
        }
        public TransactionStatus Status { get; set; }
    }
}
