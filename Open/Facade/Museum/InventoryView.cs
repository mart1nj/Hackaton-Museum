using System.ComponentModel;
using Open.Facade.Common;
namespace Open.Facade.Museum
{
    public class InventoryView : EntityView
    {
        private string employee;
        private string location;
        private string department;

        [DisplayName("Komisjoni liige")]
        public string Employee
        {
            get => getString(ref employee);
            set => employee = value;
        }
        
        [DisplayName("Asukoht")]
        public string Location
        {
            get => getString(ref location);
            set => location = value;
        }
        
        [DisplayName("Muusemikogu")]
        public string Department
        {
            get => getString(ref department);
            set => department = value;
        }
    }
}
