using System;
using System.ComponentModel;
using Open.Facade.Quantity;

namespace Open.Facade.Bank
{
    public class TransactionView : PaymentView
    {
        [DisplayName("Client")] public string ApplicationUserID { get; set; }
        [DisplayName("Explanation")]
        public string Explanation { get; set; }
    }
}