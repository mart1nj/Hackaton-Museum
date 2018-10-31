using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
namespace Open.Data.Bank
{
    // Add profile data for application users by adding properties to the SenderAccount class
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
