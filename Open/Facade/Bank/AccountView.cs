using Open.Facade.Common;
using System;
using System.ComponentModel;

namespace Open.Facade.Bank
{
    public class AccountView : EntityView
    {
        //id ja validfrom ja validto olemas
        private string type;
        private string status;
        private int amount;

        [DisplayName("Card type")]
        public string Type
        {
            get => getString(ref type);
            set => type = value;
        }

        [DisplayName("Card status")]
        public string Status
        {
            get => getString(ref status);
            set => status = value;
        }

        [DisplayName("Balance/Amount")]
        public decimal Amount
        {
            get; set;
        }
    }
}
