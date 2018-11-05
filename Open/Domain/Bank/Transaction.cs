using Open.Data.Bank;
using Open.Domain.Common;

namespace Open.Domain.Bank
{
    public sealed class Transaction: Entity<TransactionData> {
        public readonly Account SenderAccount;
        public readonly Account ReceiverAccount;

        public Transaction(TransactionData data) : base(data) {
            SenderAccount = new Account(data?.SenderAccount);
            ReceiverAccount = new Account(data?.ReceiverAccount);
        }
        
    }
}