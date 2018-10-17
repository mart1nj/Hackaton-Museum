using Open.Core;
using Open.Domain.Bank;

namespace Open.Facade.Bank
{
    public class AccountsViewsList : PaginatedList<AccountView>
    {
        public AccountsViewsList(IPaginatedList<Account> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(AccountViewFactory.Create(e)); }
        }
    }
}
