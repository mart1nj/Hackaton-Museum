using Open.Data.Bank;
using System;

namespace Open.Domain.Bank
{
    public static class AccountFactory
    {
        public static Account CreateAccount(string id, decimal? balance, string type, string status, string applicationUserId, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new AccountData
            {
                ID = id,
                Balance = balance,
                Type = type,
                Status = status,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                AspNetUserId = applicationUserId
            };
            return new Account(r);
        }

       /* public static Account CreateAccount(AccountData account)
        {
            var r = new AccountData
            {
                ID = account.ID,
                Type = account.Type,
                Status = account.Status,
                Balance = account.Balance,
                ValidFrom = account.ValidFrom,
                ValidTo = account.ValidTo,
                AspnetUserId = account.AspnetUserId
            };
            return new Account(r);
        }*/
    }
}
