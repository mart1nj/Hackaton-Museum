using Open.Data.Notification;
namespace Open.Domain.Notification
{

    public sealed class RequestStatusNotification : Notification<RequestStatusNotificationData>
    {
        public RequestStatusNotification(RequestStatusNotificationData r) : base(r ?? new RequestStatusNotificationData()) { }
    }
}


