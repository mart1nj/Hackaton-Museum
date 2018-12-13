using System.Collections.Generic;
using Open.Core;
using Open.Data.Museum;
namespace Open.Domain.Museum
{
    public class InventoryMusealsList : PaginatedList<InventoryMuseal>
    {
        public InventoryMusealsList(IEnumerable<InventoryMusealData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new InventoryMuseal(dbRecord));
            }
        }
    }
}




