using System.ComponentModel;

namespace Open.Facade.Museum
{
    public class InventoryMusealView : MusealView {
        private bool? isChecked;
        private bool? isFound;
        private bool? hasStateChanged;

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
    }
}
