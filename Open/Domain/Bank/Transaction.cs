using Open.Data.Bank;
using Open.Data.Quantity;
using Open.Domain.Common;
using Open.Domain.Quantity;

namespace Open.Domain.Bank
{
    public sealed class Transaction: Entity<TransactionData> {
        public readonly Money Amount;
        public readonly IPaymentMethod PaymentMethod;
        public readonly Client ClientData;

        public Transaction(TransactionData data) : base(data) {
            PaymentMethod = PaymentMethodFactory.Create(data?.PaymentMethod);
            ClientData = ClientFactory.CreateClient(data?.ClientData);
            var c = new Currency(data?.Currency);
            Amount = new Money(c, data?.Amount??0, data?.DateMade);
        }
        
    }
}