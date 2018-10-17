using Open.Data.Bank;
using System;
namespace Open.Domain.Bank
{
    public static class ClientFactory
    {
        public static Client CreateClient(string id, string firstName, string lastName, string geographicID, string emailID,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new ClientData
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                GeographicAddressID = geographicID,
                EmailAddressID = emailID,
                ValidFrom = validFrom?? DateTime.MinValue,
                ValidTo = validTo?? DateTime.MaxValue
            };
            return new Client(r);
        }
        public static Client CreateClient(ClientData client)
        {
            var r = new ClientData
            {
                ID = client.ID,
                FirstName = client.FirstName,
                LastName = client.LastName,
                GeographicAddressID = client.GeographicAddressID,
                EmailAddressID = client.EmailAddressID,
                ValidFrom = client.ValidFrom,
                ValidTo = client.ValidTo
            };
            return new Client(r);
        }
    }
}
