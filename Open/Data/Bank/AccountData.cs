using System;
using Open.Data.Common;
using Open.Data.Quantity;

namespace Open.Data.Bank
{
    public class AccountData : IdentifiedData
    {
        private string type;
        private string status;
        private decimal amount;
        private string clientID;
        //exp_date
        //id

        public decimal Amount
        {
            get;set;
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

        public string ClientID
        {
            get => getString(ref clientID);
            set => clientID = value;
        }
        //public ClientData Client { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual CurrencyData Currency { get; set; }
        public DateTime DateMade { get; set; }
    }
}
