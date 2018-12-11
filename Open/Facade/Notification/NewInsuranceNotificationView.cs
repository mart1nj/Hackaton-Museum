namespace Open.Facade.Notification
{
    public class NewInsuranceNotificationView : NotificationView
    {
        private string type;
        
        public string InsuranceType {
            get => getString(ref type);
            set => type = value;
        }

        public override string ToString()
        {
            return $"{InsuranceType} {Message} {ValidTo}. ";
        }
    }
}
