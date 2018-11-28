using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public sealed class RequestTransaction : Transaction
    {
        public readonly Status Status;
        public RequestTransaction(RequestTransactionData data) : base(data)
        {
            if (data?.Status != null)
            {
                Status = data.Status;
            }
        }
    }
}
