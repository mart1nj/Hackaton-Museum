using Open.Data.Bank;
using Open.Data.Common;
namespace Open.Data.Notification
{
    public class NotificationData : IdentifiedData
    {
        protected string message;
        private string senderId;
        private string receiverId;
        private bool? isSeen;

        public virtual string Message
        {
            get => getString(ref message);
            set => message = value;
        }
        public string SenderId
        {
            get => getString(ref senderId);
            set => senderId = value;
        }
        public string ReceiverId
        {
            get => getString(ref receiverId);
            set => receiverId = value;
        }
        public bool? IsSeen {
            get => getBool(ref isSeen);
            set => isSeen = value;
        }
        public AccountData Sender { get; set; }
        public AccountData Receiver { get; set; }
    }
}



