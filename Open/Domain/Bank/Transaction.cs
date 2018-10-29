using Open.Data.Bank;
using Open.Domain.Common;
using Open.Domain.Quantity;

namespace Open.Domain.Bank
{
    public sealed class Transaction: Entity<TransactionData> {
        public readonly AccountData SenderAccountData;
        public readonly AccountData ReceiverAccountData;

        public Transaction(TransactionData data) : base(data) {
            SenderAccountData = data?.SenderAccount;
            ReceiverAccountData = data?.ReceiverAccount;
        }
        
    }
}