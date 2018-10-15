using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public static class ClientFactory
    {
        public static Client CreateClient(string id, string firstName, string lastName, string passwordHash, string geographicID, string emailID,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new ClientData
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                //PasswordHash = passwordHash,
                GeographicAddressDataID = geographicID,
                EmailAddressDataID = emailID,
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
                //PasswordHash = passwordHash,
                GeographicAddressDataID = client.GeographicAddressDataID,
                EmailAddressDataID = client.EmailAddressDataID,
                ValidFrom = client.ValidFrom,
                ValidTo = client.ValidTo
            };
            return new Client(r);
        }
    }
}
