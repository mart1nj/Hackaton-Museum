namespace Open.Data.Notification
{
    public class NewRequestTransactionNotificationData : NewTransactionNotificationData
    {
        public override string Message
        {
            get => getString(ref message, "has requested a transaction in the amount of");
            set => message = value;
        }
    }
}
