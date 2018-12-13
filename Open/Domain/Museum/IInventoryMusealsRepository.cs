using System.Threading.Tasks;
using Open.Core;
using Open.Data.Museum;
namespace Open.Domain.Museum
{
    public interface IInventoryMusealsRepository : IRepository<InventoryMuseal, InventoryMusealData>
   {
        Task<IPaginatedList<InventoryMuseal>> GetInventoryMusealsList(string inventoryID);
        Task<IPaginatedList<InventoryMuseal>> GetMusealInventoriesList(string musealID);
    }
}



