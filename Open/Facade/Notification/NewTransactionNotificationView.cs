namespace Open.Facade.Notification
{
    public class NewTransactionNotificationView : NotificationView {
        private decimal? amount;

        public decimal? Amount {
            get => getDecimal(ref amount);
            set => amount = value;
        }
        public override string ToString()
        {
            return $"{SenderAccountId} {Message} {Amount}. ";
        }
    }
}
