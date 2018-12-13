using System.Collections.Generic;
using Open.Core;
using Open.Data.Museum;
namespace Open.Domain.Museum
{
    public class InventoriesList : PaginatedList<Inventory>
    {
        public InventoriesList(IEnumerable<InventoryData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new Inventory(dbRecord));
            }
        }
    }
}




