using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public interface IAccountsRepository : IRepository<Account, AccountData> {
        Task<PaginatedList<Account>> LoadAccountsForUser(string id);
    }
}
