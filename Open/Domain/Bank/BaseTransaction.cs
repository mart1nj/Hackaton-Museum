using Open.Data.Bank;
using Open.Domain.Common;

namespace Open.Domain.Bank
{
    public abstract class BaseTransaction<T> : Entity<T>, ITransaction where T : BaseTransactionData, new()
    {
        public readonly Account SenderAccount;
        public readonly Account ReceiverAccount;
        protected BaseTransaction(T r) : base(r)
        {
            SenderAccount = new Account(r?.SenderAccount);
            ReceiverAccount = new Account(r?.ReceiverAccount);
        }

    }
}