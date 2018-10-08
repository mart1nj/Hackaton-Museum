using System.Collections.Generic;
using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public class ClientsList : PaginatedList<Client>
    {
        public ClientsList(IEnumerable<ClientData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new Client(dbRecord));
            }
        }
    }
}
