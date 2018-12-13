using Open.Core;
using System.ComponentModel;
namespace Open.Facade.Museum
{
    public class InventoryMusealView : MusealView {
        private bool? isChecked;
        private bool? isFound;
        private bool? hasStateChanged;
        private string musealID;
        private string inventoryID;
        private string damagesNow;
        private string picture;
        private string text;

        [DisplayName("Kontrollitud?")]
        public bool? IsChecked
        {
            get => getBool(ref isChecked);
            set => isChecked = value;
        }

        [DisplayName("Leitud?")]
        public bool? IsFound
        {
            get => getBool(ref isFound);
            set => isFound = value;
        }

        [DisplayName("Olukord muutunud?")]
        public bool? HasStateChanged
        {
            get => getBool(ref hasStateChanged);
            set => hasStateChanged = value;
        }

        [DisplayName("Seisund nüüd")]
        public MusealState StateNow { get; set; }

        [DisplayName("Kahjustused nüüd")]
        public string DamagesNow
        {
            get => getString(ref damagesNow);
            set => damagesNow = value;
        }
        [DisplayName("Museaali number")]
        public string MusealID
        {
            get => getString(ref musealID);
            set => musealID = value;
        }
        [DisplayName("Inventaari number")]
        public string InventoryID
        {
            get => getString(ref inventoryID);
            set => inventoryID = value;
        }

        [DisplayName("Pilt")]
        public string Picture
        {
            get => getString(ref picture);
            set => picture = value;
        }

        [DisplayName("Kommentaar")]
        public string Text
        {
            get => getString(ref text);
            set => text = value;
        }
    }
}
