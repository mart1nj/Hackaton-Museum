using Open.Data.Bank;
using System;

namespace Open.Domain.Bank
{
    public static class AccountFactory
    {
        public static Account CreateAccount(string id, string type, string status, int amount, string clientID, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new AccountData
            {
                ID = id,
                Type = type,
                Status = status,
                Amount = amount,
                ClientID = clientID,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Account(r);
        }

        public static Account CreateAccount(AccountData account)
        {
            var r = new AccountData
            {
                ID = account.ID,
                Type = account.Type,
                Status = account.Status,
                Amount = account.Amount,
                ClientID = account.ClientID,
                ValidFrom = account.ValidFrom,
                ValidTo = account.ValidTo
            };
            return new Account(r);
        }
    }
}
