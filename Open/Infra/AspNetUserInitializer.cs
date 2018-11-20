using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Open.Data.Bank;
using Open.Data.Party;
namespace Open.Infra {
    public class AspNetUserInitializer {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            var userAddressId = Guid.NewGuid().ToString();
            var userAddress = new GeographicAddressData {
                ID = userAddressId,
                Address = "Test Lane 5",
                ZipOrPostCodeOrExtension = "12345",
                CityOrAreaCode = "Test City",
                RegionOrStateOrCountryCode = "Siilimäe",
                CountryID = "EST",
            };
            var user = new ApplicationUser
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@sonic.com",
                NormalizedEmail = "TEST@SONIC.COM",
                UserName = "test@sonic.com",
                NormalizedUserName = "TEST@SONIC.COM",
                PhoneNumber = "+111111111111",
                Address = userAddress,
                AddressID = userAddressId,
                DateOfBirth = DateTime.ParseExact("27/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id = "testUserid"
            };
            var user2AddressId = Guid.NewGuid().ToString();
            var user2Address = new GeographicAddressData
            {
                ID = user2AddressId,
                Address = "Test Lane 4",
                ZipOrPostCodeOrExtension = "12344",
                CityOrAreaCode = "Test City",
                RegionOrStateOrCountryCode = "Mustamäe",
                CountryID = "EST",
            };
            var user2 = new ApplicationUser
            {
                FirstName = "Sonic",
                LastName = "Siil",
                Email = "siil@sonic.com",
                NormalizedEmail = "SIIL@SONIC.COM",
                UserName = "siil@sonic.com",
                NormalizedUserName = "SIIL@SONIC.COM",
                PhoneNumber = "+111111111111",
                Address = user2Address,
                AddressID = user2AddressId,
                DateOfBirth = DateTime.ParseExact("29/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id = "sonicSiilId"
            };

            var systemAddressId = Guid.NewGuid().ToString();
            var systemAddress = new GeographicAddressData
            {
                ID = systemAddressId,
                Address = "null",
                ZipOrPostCodeOrExtension = "12345",
                CityOrAreaCode = "null",
                RegionOrStateOrCountryCode = "Siliine",
                CountryID = "EST",
            };
            var system = new ApplicationUser
            {
                FirstName = "System",
                LastName = "User",
                Email = "system@sonic.com",
                NormalizedEmail = "SYSTEM@SONIC.COM",
                UserName = "system@sonic.com",
                NormalizedUserName = "SYSTEM@SONIC.COM",
                PhoneNumber = "+111111111111",
                Address = systemAddress,
                AddressID = systemAddressId,
                DateOfBirth = DateTime.ParseExact("07/11/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id = "system"
            };
            if (!context.Users.Any(u => u.UserName == user2.UserName) || !context.Users.Any(u => u.UserName == user.UserName) || !context.Users.Any(u => u.UserName == system.UserName))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                hashPasswordAndCreateUser(userStore, user, "secret");
                hashPasswordAndCreateUser(userStore, user2, "secret");
                hashPasswordAndCreateUser(userStore, system, "secret");
            }
            context.SaveChangesAsync();
        }
        private static void hashPasswordAndCreateUser(UserStore<ApplicationUser> userStore,
            ApplicationUser user, string pass)
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, pass);
            user.PasswordHash = hashed;
            var result = userStore.CreateAsync(user);

        }
    }
}