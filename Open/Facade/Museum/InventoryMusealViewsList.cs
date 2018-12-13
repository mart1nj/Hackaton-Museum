using Open.Core;
using Open.Domain.Museum;
namespace Open.Facade.Museum
{
    public class InventoryMusealViewsList : PaginatedList<InventoryMusealView>
    {
        public InventoryMusealViewsList(IPaginatedList<InventoryMuseal> invList, IPaginatedList<Museal> musList)
        {
            if (musList is null) return;
            PageIndex = musList.PageIndex;
            TotalPages = musList.TotalPages;
            foreach (var museal in musList) {
                foreach (var inventoryMuseal in invList) {
                    if (museal.Data?.ID == inventoryMuseal.Data?.MusealID &&
                        museal.Data?.ID != "Unspecified") {
                        Add(MusealViewFactory.CreateInventoryMuseal(museal, inventoryMuseal));

                    }
                }
            }
        }
    }
}



