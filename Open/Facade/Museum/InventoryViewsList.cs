using Open.Core;
using Open.Domain.Museum;
namespace Open.Facade.Museum
{
    public class InventoryViewsList : PaginatedList<InventoryView>
    {
        public InventoryViewsList(IPaginatedList<Inventory> invList)
        {
            if (invList is null) return;
            PageIndex = invList.PageIndex;
            TotalPages = invList.TotalPages;
            foreach (var inv in invList)
            {
                Add(MusealViewFactory.CreateInventory(inv));
            }
        }
    }
}



