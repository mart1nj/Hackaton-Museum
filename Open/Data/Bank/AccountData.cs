using Open.Data.Common;

namespace Open.Data.Bank
{
    public class AccountData : IdentifiedData
    {
        private string type;
        private string status;
        private double? balance;
        private string applicationUserId;
        public double? Balance
        {
            get => getDouble(ref balance);
            set => balance = value;
        }
        public string Type
        {
            get => getString(ref type);
            set => type = value;
        }
        public string Status
        {
            get => getString(ref status);
            set => status = value;
        }
        public string AspnetUserId {
            get => getString(ref applicationUserId);
            set => applicationUserId = value;
        }
        public virtual ApplicationUser AspNetUser { get; set; }
      
    }
}
