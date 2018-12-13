using Open.Data.Common;

namespace Open.Data.Museum
{
    public class InventoryData : IdentifiedData
    {
        private string employee;

        public string Employee
        {
            get => getString(ref employee);
            set => employee = value;
        }
    }
}
