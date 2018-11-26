using Open.Data.Bank;
using Open.Domain.Common;
namespace Open.Domain.Bank
{
    public sealed class Insurance : Entity<InsuranceData>
    {
        public readonly ApplicationUser ApplicationUser;
        public Insurance(InsuranceData data) : base(data)
        {
            ApplicationUser = data?.AspNetUser;
        }
    }
}
