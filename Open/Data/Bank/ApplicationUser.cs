using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Open.Data.Party;
namespace Open.Data.Bank
{
    // Add profile data for application users by adding properties to the SenderAccount class
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressID { get; set; }
        public GeographicAddressData Address { get; set; }     
        public DateTime? DateOfBirth { get; set; }
    }
}
