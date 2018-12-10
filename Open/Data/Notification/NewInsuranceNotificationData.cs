namespace Open.Data.Notification
{
    public class NewInsuranceNotificationData : NotificationData
    {
        private string type;
        
        public override string Message
        {
            get => getString(ref message, "insurance is now valid until");
            set => message = value;
        }
        
        public string InsuranceType {
            get => getString(ref type);
            set => type = value;
        }
    }
}
