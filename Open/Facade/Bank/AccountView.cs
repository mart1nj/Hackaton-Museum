using System.ComponentModel.DataAnnotations;
using Open.Data.Bank;
using Open.Facade.Common;

namespace Open.Facade.Bank {
    public class AccountView : EntityView {
        private string type;
        private string status;
        private decimal? balance;
        private string aspNetUserId;

        [Required]
        public decimal? Balance {
            get => getDecimal(ref balance);
            set => balance = value;
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
