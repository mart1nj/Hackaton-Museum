using Open.Data.Common;
namespace Open.Data.Bank
{
    public class InsuranceData : IdentifiedData {
        private string type;
        private string status;
        private decimal? payment;
        private string applicationUserId;

        public decimal? Payment {
            get => getDecimal(ref payment);
            set => payment = value;
        }

        public string Type {
            get => getString(ref type);
            set => type = value;
        }

        public string Status {
            get => getString(ref status);
            set => status = value;
        }

        public string AspNetUserId {
            get => getString(ref applicationUserId);
            set => applicationUserId = value;
        }

        public virtual ApplicationUser AspNetUser { get; set; }
    }
}
