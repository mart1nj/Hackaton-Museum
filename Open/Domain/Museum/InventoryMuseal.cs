using Open.Data.Museum;
using Open.Domain.Common;
namespace Open.Domain.Museum
{

    public sealed class InventoryMuseal : Entity<InventoryMusealData>
    {
        public readonly Museal Museal;
        public readonly Inventory Inventory;
        public InventoryMuseal(InventoryMusealData r) : base(
            r ?? new InventoryMusealData())
        {
            Museal = new Museal(Data.Museal);
            Inventory = new Inventory(Data.Inventory);
        }
    }
}


