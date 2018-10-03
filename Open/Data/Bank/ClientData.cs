using Open.Data.Common;
namespace Open.Data.Bank
{
    public class ClientData : IdentifiedData
    {
        private string partyId;
        private string firstName;
        private string lastName;
        private string passwordHash;

        public string PartyId
        {
            get => getString(ref partyId);
            set => partyId = value;
        }

        public string FirstName
        {
            get => getString(ref firstName);
            set => firstName = value;
        }

        public string LastName
        {
            get => getString(ref lastName);
            set => lastName = value;
        }
    }
}
