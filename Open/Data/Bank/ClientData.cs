using Open.Data.Common;
using Open.Data.Party;

namespace Open.Data.Bank {
    public class ClientData : IdentifiedData {
        private string firstName;
        private string lastName;
        private string geographicAddressID;
        private string emailAddressID;

        public string FirstName {
            get => getString(ref firstName);
            set => firstName = value;
        }

        public string LastName {
            get => getString(ref lastName);
            set => lastName = value;
        }

        public string GeographicAddressID {
            get => getString(ref geographicAddressID);
            set => geographicAddressID = value;
        }

        public string EmailAddressID {
            get => getString(ref emailAddressID);
            set => emailAddressID = value;
        }
        public GeographicAddressData GeographicAddress { get; set; }

        public EmailAddressData EmailAddress { get; set; }
    }
}
