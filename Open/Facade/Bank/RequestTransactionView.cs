using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;

namespace Open.Facade.Bank
{
    public class RequestTransactionView : TransactionView
    {
        public TransactionStatus Status { get; set; }

        [Required]
        [DisplayName("Request Sent To")]
        public new string SenderAccountId
        {
            get => getString(ref sAccountId);
            set => sAccountId = value;
        }
        [Required]
        [DisplayName("Request Sent By")]
        public new string ReceiverAccountId
        {
            get => getString(ref rAccountId);
            set => rAccountId = value;
        }
    }
}
