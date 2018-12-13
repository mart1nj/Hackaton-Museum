using System.ComponentModel;
using Open.Core;
using Open.Facade.Common;
namespace Open.Facade.Museum
{

    public class MusealView : EntityView {
        private string author;
        private string designation;
        private string info;
        private string damagesBefore;
        private string defaultLocation;
        private string currentLocation;

        [DisplayName("Identifikaator")]
        public new string ID
        {
            get => getString(ref id);
            set => id = value;
        }
        [DisplayName("Autor")]
        public string Author
        {
            get => getString(ref author);
            set => author = value;
        }
        [DisplayName("Nimetus")]
        public string Designation
        {
            get => getString(ref designation);
            set => designation = value;
        }
        [DisplayName("Üldinfo")]
        public string Info
        {
            get => getString(ref info);
            set => info = value;
        }

        [DisplayName("Seisund enne")]
        public MusealState StateBefore { get; set; }

        [DisplayName("Kahjustused enne")]
        public string DamagesBefore
        {
            get => getString(ref damagesBefore);
            set => damagesBefore = value;
        }
        [DisplayName("Püsiasukoht")]
        public string DefaultLocation
        {
            get => getString(ref defaultLocation);
            set => defaultLocation = value;
        }
        [DisplayName("Jooksev asukoht")]
        public string CurrentLocation
        {
            get => getString(ref currentLocation);
            set => currentLocation = value;
        }
    }
}



