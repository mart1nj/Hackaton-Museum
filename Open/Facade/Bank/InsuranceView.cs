using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Open.Data.Bank;
using Open.Facade.Common;
namespace Open.Facade.Bank
{
    public class InsuranceView : EntityView {
        private string type;
        private string status;
        private string accountId;
        private string paymentInStringFormat;
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public override DateTime? ValidFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public override DateTime? ValidTo { get; set; }
        
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue)]
        [Required]
        [DisplayName("Payment")]
        public string PaymentInStringFormat {
            get => getString(ref paymentInStringFormat, "0");
            set => paymentInStringFormat = value;            
        }
        public decimal? Payment {
            get {
                var toDecimal = stringToDecimal(paymentInStringFormat);
                return getDecimal(ref toDecimal);
            }
            set => paymentInStringFormat = value.ToString();
        }
        private static decimal? stringToDecimal(string str) {
            str = str.Replace(',', '.');
            return decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture,
                out var value)
                ? value
                : 0;
        }

        [Required]
        public string Type {
            get => getString(ref type);
            set => type = value;
        }

        [Required]
        public string Status {
            get => getString(ref status);
            set => status = value;
        }

        [Required]
        public string AccountId {
            get => getString(ref accountId);
            set => accountId = value;
        }

        public virtual AccountData Account { get; set; }
    }
}
