using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;

namespace Open.Facade.Bank
{
    public class RequestTransactionView : TransactionView
    {
        public TransactionStatus Status { get; set; }

        [Required]
        [DisplayName("Sender account number")]
        public new string SenderAccountId
        {
            get => getString(ref sAccountId);
            set => sAccountId = value;
        }
    }
}
