using Open.Core;
using Open.Data.Common;
namespace Open.Data.Museum
{

    public class MusealData : IdentifiedData
    {
        private string author;
        private string designation;
        private string info;
        private string damagesBefore;
        private string defaultLocation;
        private string currentLocation;

        public string Author
        {
            get => getString(ref author);
            set => author = value;
        }
        public string Designation
        {
            get => getString(ref designation);
            set => designation = value;
        }
        public string Info
        {
            get => getString(ref info);
            set => info = value;
        }
        public MusealState StateBefore { get; set; }
        public string DamagesBefore
        {
            get => getString(ref damagesBefore);
            set => damagesBefore = value;
        }
        public string DefaultLocation
        {
            get => getString(ref defaultLocation);
            set => defaultLocation = value;
        }
        public string CurrentLocation
        {
            get => getString(ref currentLocation);
            set => currentLocation = value;
        }
    }
}



