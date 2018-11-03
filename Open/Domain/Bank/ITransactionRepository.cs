using System.Threading.Tasks;
using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public interface ITransactionRepository : IRepository<Transaction, TransactionData> {
        Task<PaginatedList<Transaction>> LoadTransactionsForAccount(string id);
    }
}