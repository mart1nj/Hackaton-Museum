using Open.Data.Bank;
using Open.Domain.Common;

namespace Open.Domain.Bank
{
    public sealed class Account : Entity<AccountData>
    {
        public readonly ApplicationUser ApplicationUser;
        public Account(AccountData data) : base(data)
        {
            ApplicationUser = data?.AspNetUser;
        }
    }
}