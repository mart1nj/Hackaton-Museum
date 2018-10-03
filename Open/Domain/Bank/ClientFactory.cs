using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public static class ClientFactory
    {
        public static Client CreateClient(string id, string firstName, string lastName, string passwordHash)
        {
            var r = new ClientData
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                //PasswordHash = passwordHash
            };
            return new Client(r);
        }
    }
}
