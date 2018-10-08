using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Party;
using Open.Facade.Common;

namespace Open.Facade.Bank
{
    public class ClientView : EntityView {
        private string firstName;
        private string lastName;
        private string geographicAddressID;
        private string emailAddressID;

        [Required]
        [DisplayName("First Name")]
        public string FirstName {
            get => getString(ref firstName);
            set => firstName = value;
        }

        [Required]
        [DisplayName("Last Name")]
        public string LastName {
            get => getString(ref lastName);
            set => lastName = value;
        }
        
        public string GeographicAddressID
        {
            get => getString(ref geographicAddressID);
            set => geographicAddressID = value;
        }
        public string EmailAddressID
        {
            get => getString(ref emailAddressID);
            set => emailAddressID = value;
        }
    }
}

