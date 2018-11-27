using Open.Core;
using Open.Data.Bank;
using Open.Domain.Common;

namespace Open.Domain.Bank
{
    public sealed class RequestTransaction : Entity<RequestTransactionData>
    {
        public readonly Account SenderAccount;
        public readonly Account ReceiverAccount;
        public readonly Status Status;
        public RequestTransaction(RequestTransactionData data) : base(data)
        {
            SenderAccount = new Account(data?.SenderAccount);
            ReceiverAccount = new Account(data?.ReceiverAccount);
            if (data?.Status != null)
            {
                Status = data.Status;
            }
        }
    }
}
