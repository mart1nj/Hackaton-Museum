using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Infra.Bank
{
    public class AccountRepository : Repository<Account, AccountData>, IAccountsRepository
    {
        public AccountRepository(ApplicationDbContext c) : base(c?.Accounts, c) { }

        protected internal override Account createObject(AccountData r) { return new Account(r); }

        protected internal override PaginatedList<Account> createList(List<AccountData> l,
            RepositoryPage p)
        {
            return new AccountList(l, p);
        }

        protected internal override async Task<AccountData> getObject(string id)
        {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<PaginatedList<Account>> LoadAccountsForUser(string id)
        {
            var accounts = getSorted().Where(s => s.Contains(SearchString) && s.AspNetUserId == id).AsNoTracking();
            var count = await accounts.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await accounts.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}
