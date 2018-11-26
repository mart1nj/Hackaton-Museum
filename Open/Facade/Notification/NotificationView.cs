using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Bank;
using Open.Facade.Common;
namespace Open.Facade.Notification
{

    public abstract class NotificationView : EntityView
    {
        private string message;
        private string senderAccountId;
        private string receiverAccountId;
        private bool? isSeen;

        [DisplayName("Notification type")]
        public string NotificationType
        {
            get
            {
                var name = GetType().Name;
                var suffix = typeof(NotificationView).Name;
                var idx = name.IndexOf(suffix, StringComparison.Ordinal);
                if (idx >= 0) name = name.Substring(0, idx);
                return name;
            }
        }
        [Required]
        public virtual string Message
        {
            get => getString(ref message);
            set => message = value;
        }
        [DisplayName("Sent From")]
        public string SenderAccountId {
            get => getString(ref senderAccountId);
            set => senderAccountId = value;
        }
        [DisplayName("Sent To")]
        public string ReceiverAccountId
        {
            get => getString(ref receiverAccountId);
            set => receiverAccountId = value;
        }
        public bool? IsSeen
        {
            get => getBool(ref isSeen);
            set => isSeen = value;
        }

        [DisplayName("Sent at")]
        public new DateTime? ValidFrom { get; set; }

        public AccountView Sender { get; set; }
        public AccountView Receiver { get; set; }

        public string FormattedMessage => ToString();

    }

}



