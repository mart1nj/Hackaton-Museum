using Open.Data.Bank;
using Open.Domain.Common;
namespace Open.Domain.Bank
{
    public sealed class Insurance : Entity<InsuranceData>
    {
        public readonly Account Account;
        public Insurance(InsuranceData data) : base(data)
        {
            Account = new Account(data?.Account);
        }
    }
}
