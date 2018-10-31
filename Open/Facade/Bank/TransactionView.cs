using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;

namespace Open.Facade.Bank
{
    public class TransactionView : EntityView
    {
        private double? amount;
        private string explanation;
        private string sAccountId;
        private string rAccountId;
        [Required]
        public double? Amount
        {
            get => getDouble(ref amount);
            set => amount = value;
        }
        [Required]
        public string Explanation
        {
            get => getString(ref explanation);
            set => explanation = value;
        }
        [Required]
        [DisplayName("Sender Account Number")]
        public string SenderAccountId
        {
            get => getString(ref sAccountId);
            set => sAccountId = value;
        }
        [Required]
        [DisplayName("Receiver Account Number")]
        public string ReceiverAccountId
        {
            get => getString(ref rAccountId);
            set => rAccountId = value;
        }
        [DataType(DataType.Date)]
        [DisplayName("Date Made")]
        public new DateTime? ValidFrom { get; set; }

        public AccountView SenderAccount { get; set; }
        public AccountView ReceiverAccount { get; set; }
    }
}
