namespace Open.Data.Notification
{
    public class NewTransactionNotificationData : NotificationData {
        private decimal? amount;

        public override string Message
        {
            get => getString(ref message, "has sent you a new transaction in the amount of");
            set => message = value;
        }

        public decimal? Amount {
            get => getDecimal(ref amount);
            set => amount = value;
        }
    }
}
