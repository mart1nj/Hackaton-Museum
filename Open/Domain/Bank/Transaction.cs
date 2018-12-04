using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public class Transaction: BaseTransaction<TransactionData> {
        public Transaction(TransactionData data) : base(data) {
        }       
    }
}