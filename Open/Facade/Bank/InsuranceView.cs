using System.ComponentModel.DataAnnotations;
using Open.Data.Bank;
using Open.Facade.Common;
namespace Open.Facade.Bank
{
    public class InsuranceView : EntityView {
        private string type;
        private string status;
        private decimal? payment;
        private string aspNetUserId;

        [Required]
        public decimal? Payment {
            get => getDecimal(ref payment);
            set => payment = value;
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
        public string AspNetUserId {
            get => getString(ref aspNetUserId);
            set => aspNetUserId = value;
        }

        public ApplicationUser AspNetUser { get; set; }
    }
}
