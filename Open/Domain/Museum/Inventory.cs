using Open.Data.Museum;
using Open.Domain.Common;
namespace Open.Domain.Museum
{

    public sealed class Inventory : Entity<InventoryData>
    {
        public Inventory(InventoryData r) : base(r ?? new InventoryData())
        {
        }
    }
}


