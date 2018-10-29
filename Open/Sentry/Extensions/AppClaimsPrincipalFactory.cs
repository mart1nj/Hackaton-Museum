using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Open.Data.Bank;
namespace Open.Sentry.Extensions
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
        /*    identity.AddClaim(new Claim(ClaimTypes.StreetAddress, user.AddressLine ?? ""));
            identity.AddClaim(new Claim(ClaimTypes.PostalCode, user.ZipCode ?? ""));
            identity.AddClaim(new Claim(ClaimTypes.Locality, user.City ?? ""));
            identity.AddClaim(new Claim(ClaimTypes.Country, user.Country ?? ""));
            identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString() ?? ""));*/

            return identity;
        }
    }
}
