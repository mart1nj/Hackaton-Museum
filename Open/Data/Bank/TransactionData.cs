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

        public string Clarification { get; set; }

        public string TransactionAccountNr { get; set; }   
        
        public virtual PaymentMethodData PaymentMethodID { get; set; }

        public virtual ClientData ClientData { get; set; }
    }
}