using System.ComponentModel;
using Open.Facade.Common;
namespace Open.Facade.Museum
{
    public class InventoryView : EntityView
    {
        private string employee;

        [DisplayName("Töötaja")]
        public string Employee
        {
            get => getString(ref employee);
            set => employee = value;
        }
    }
}
