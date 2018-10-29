using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;

namespace Open.Facade.Bank
{
    public class AccountView : EntityView
    {
        private string type;
        private string status;
        private double? balance;
        private string applicationUserId;
        [Required]
        public double? Balance
        {
            get => getDouble(ref balance);
            set => balance = value;
        }
        [Required]
        public string Type
        {
            get => getString(ref type);
            set => type = value;
        }
        [Required]
        public string Status
        {
            get => getString(ref status);
            set => status = value;
        }
        [Required]
        public string ApplicationUserId
        {
            get => getString(ref applicationUserId);
            set => applicationUserId = value;
        }
    }
}
