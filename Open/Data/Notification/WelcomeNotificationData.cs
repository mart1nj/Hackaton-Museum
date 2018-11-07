namespace Open.Data.Notification
{
    public class WelcomeNotificationData : NotificationData {
        public override string Message {
            get => getString(ref message, "Welcome to SonicBank! Thank you for opening an account!");
            set => message = value;
        }
    }
}
