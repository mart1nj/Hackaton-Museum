using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public class RequestTransaction : BaseTransaction<RequestTransactionData>
    {
        public RequestTransaction(RequestTransactionData data) : base(data) { }
    }
}
