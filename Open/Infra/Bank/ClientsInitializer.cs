using System;
using System.Linq;
using Open.Data.Bank;
using Open.Data.Party;

namespace Open.Infra.Bank
{
    public static class ClientsInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Clients.Any()) return;
            initAdminAccount(c);
            c.SaveChanges();
        }

        private static void initAdminAccount(SentryDbContext c)
        {
            EmailAddressData email = new EmailAddressData {Address = "siilsonic@sonicbank.com", ID = Guid.NewGuid().ToString()};
            GeographicAddressData geoAddress = new GeographicAddressData
            {
                Address = "Sooniku tee 5",
                CityOrAreaCode = "Tallinn",
                RegionOrStateOrCountryCode = "Harjumaa",
                CountryID = "EST",
                ZipOrPostCodeOrExtension = "12618",
                ID = Guid.NewGuid().ToString()
            };
            c.Addresses.Add(email);
            c.Addresses.Add(geoAddress);
            ClientData admin = new ClientData
            {
                FirstName = "Sonic",
                LastName = "The HedgeHog",
                EmailAddressID = email.ID,
                GeographicAddressID = geoAddress.ID,
                ID = Guid.NewGuid().ToString(),
            };
            c.Clients.Add(admin);
            c.SaveChanges();
        }

        private static void addAddress(SentryDbContext c, AddressData address) {
            address.ID = Guid.NewGuid().ToString();
            c.Addresses.Add(address);
        }
    }
}