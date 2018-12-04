using System.Threading.Tasks;
using Open.Core;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public interface IRequestTransactionRepository : IRepository<RequestTransaction, RequestTransactionData>
    {
        Task<PaginatedList<RequestTransaction>> LoadReceivedRequestsForAccount(string id);
        Task<PaginatedList<RequestTransaction>> LoadSentRequestsForAccount(string id);

    }
}
