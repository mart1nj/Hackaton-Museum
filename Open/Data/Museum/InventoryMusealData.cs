using Open.Core;
using Open.Data.Common;
namespace Open.Data.Museum
{
    public class InventoryMusealData : IdentifiedData
    {
        private bool? isChecked;
        private bool? isFound;
        private bool? hasStateChanged;
        private string damages;
        private string musealID;
        private string inventoryID;


        public bool? IsChecked
        {
            get => getBool(ref isChecked);
            set => isChecked = value;
        }
        public bool? IsFound
        {
            get => getBool(ref isFound);
            set => isFound = value;
        }
        public bool? HasStateChanged
        {
            get => getBool(ref hasStateChanged);
            set => hasStateChanged = value;
        }
        public MusealState State { get; set; }
        public string Damages
        {
            get => getString(ref damages);
            set => damages = value;
        }

        public string MusealID
        {
            get => getString(ref musealID);
            set => musealID = value;
        }

        public string InventoryID
        {
            get => getString(ref inventoryID);
            set => inventoryID = value;
        }
        public virtual MusealData Museal { get; set; }

        public virtual InventoryData Inventory { get; set; }
    }
}
