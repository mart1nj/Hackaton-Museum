using Open.Data.Bank;
using Open.Domain.Common;
using Open.Domain.Party;

namespace Open.Domain.Bank {
    
    public sealed class Client : Entity<ClientData> {
        
        public readonly GeographicAddress GeographicAddress;
        public readonly EmailAddress EmailAddress;

        public Client(ClientData r) : base(r?? new ClientData()) {
            GeographicAddress = new GeographicAddress(Data.GeographicAddress);
            EmailAddress = new EmailAddress(Data.EmailAddress);
        }
    }
}


