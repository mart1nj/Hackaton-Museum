using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Open.Facade.Common;

namespace Open.Facade.Bank
{
    public class TransactionView : EntityView
    {
        private string explanation;
        protected string sAccountId;
        protected string rAccountId;
        private string amountInStringFormat;

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue)]
        [Required]
        [DisplayName("Amount")]
        public string AmountInStringFormat {
            get => getString(ref amountInStringFormat, "0");
            set => amountInStringFormat = value;            
        }
        
        public decimal? Amount {
            get {
                var toDecimal = stringToDecimal(amountInStringFormat);
                return getDecimal(ref toDecimal);
            }
            set => amountInStringFormat = value.ToString();
        }
        
        private static decimal? stringToDecimal(string str) {
            str = str.Replace(',', '.');
            return decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture,
                out var value)
                ? value
                : 0;
        }
        
        [Required]
        public string Explanation
        {
            get => getString(ref explanation);
            set => explanation = value;
        }
        
        [Required]
        [DisplayName("Sender/Receiver")]
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
        
        [DataType(DataType.DateTime)]
        [DisplayName("Date Made")]
        public new DateTime? ValidFrom { get; set; }

        public AccountView SenderAccount { get; set; }
        public AccountView ReceiverAccount { get; set; }
    }
}
