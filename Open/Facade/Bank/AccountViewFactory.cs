using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
using System;

namespace Open.Facade.Bank
{
    public class AccountViewFactory
    {
        public static AccountView Create(Account o)
        {
            var v = new AccountView
            {
                Type = o?.Data.Type,
                Status = o?.Data.Status,
                Balance = o?.Data.Balance ?? 0,
                ID = o?.Data?.ID,
                AspNetUserId = o?.Data?.AspNetUserId
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
        
     /*   public static Account Create(AccountView v)
        {
            var r = new AccountData
            {
                Balance = v?.Balance ?? 0,
                Type = v?.Type,
                Status= v?.Status,
                ValidFrom = v?.ValidFrom ?? DateTime.MinValue,
                ValidTo = v?.ValidTo?? DateTime.MaxValue,
                ID = v?.ID,
                AspNetUserId = v?.AspNetUserId
            };
            return new Account(r);
        }*/
    }
}
