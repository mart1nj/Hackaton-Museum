using Open.Data.Notification;
using Open.Domain.Bank;
using Open.Domain.Common;
namespace Open.Domain.Notification
{
    public abstract class Notification<T> : Entity<T>, INotification where T : NotificationData, new()
    {
        public readonly Account Sender;
        public readonly Account Receiver;

        protected Notification(T r) : base(r)
        {
            Sender = new Account(Data.Sender);
            Receiver = new Account(Data.Receiver);
        }
    }

}

