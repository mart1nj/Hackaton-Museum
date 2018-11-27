using Open.Data.Common;
namespace Open.Data.Bank
{
    public class InsuranceData : IdentifiedData {
        private string type;
        private string status;
        private decimal? payment;
        private string accountId;

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

        public string AccountId {
            get => getString(ref accountId);
            set => accountId = value;
        }

        public virtual AccountData Account { get; set; }
    }
}
