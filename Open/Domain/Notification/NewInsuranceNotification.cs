using Open.Data.Notification;
namespace Open.Domain.Notification
{
    public sealed class NewInsuranceNotification : Notification<NewInsuranceNotificationData>
    {
        public NewInsuranceNotification(NewInsuranceNotificationData r) : base(r ?? new NewInsuranceNotificationData()) { }
    }
}
