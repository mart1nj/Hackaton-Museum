using Open.Core;
using Open.Data.Bank;
using System.Collections.Generic;

namespace Open.Domain.Bank
{
    public class AccountList : PaginatedList<Account>
    {
        public AccountList(IEnumerable<AccountData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new Account(dbRecord));
            }
        }
    }
}
