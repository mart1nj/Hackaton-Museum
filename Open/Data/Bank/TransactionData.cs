using System;
using Open.Data.Common;
using Open.Data.Quantity;

namespace Open.Data.Bank
{
    public class TransactionData : IdentifiedData {
        
        public decimal Amount { get; set; }

        public DateTime DateMade {
            get => ValidFrom;
            set => ValidFrom = value;
        }        

        public string Explanation { get; set; }

        public string TransactionAccountNr { get; set; }   
        
        public virtual PaymentMethodData PaymentMethod { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
                public virtual CurrencyData Currency { get; set; }
    }
}