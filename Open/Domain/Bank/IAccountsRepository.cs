using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public interface IAccountsRepository : IRepository<Account, AccountData>
    {
    }
}
