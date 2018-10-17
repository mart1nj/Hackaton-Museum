using Open.Data.Bank;
using Open.Domain.Common;
using Open.Domain.Quantity;

namespace Open.Domain.Bank
{
    public sealed class Account : Entity<AccountData>
    {
        public readonly Client Client;
        public readonly Money Amount;
        public Account(AccountData data) : base(data)
        {
            ApplicationUser = data?.ApplicationUser;
            var c = new Currency(data?.Currency);
            Amount= new Money(c, data?.Amount?? 0, data?.DateMade);
        }
    }
}