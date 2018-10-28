﻿using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Open.Data.Bank;
namespace Open.Sentry.Data {
    public class SampleDataInitializer {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            var user = new ApplicationUser
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@sonic.com",
                NormalizedEmail = "TEST@SONIC.COM",
                UserName = "test@sonic.com",
                NormalizedUserName = "TEST@SONIC.COM",
                PhoneNumber = "+111111111111",
                AddressLine = "Test Lane 5",
                ZipCode = "12345",
                City = "Test City",
                Country = "Estonia",
                DateOfBirth = DateTime.ParseExact("27/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id = "testUserid"
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);

            }
            context.SaveChangesAsync();
        }
    }
}