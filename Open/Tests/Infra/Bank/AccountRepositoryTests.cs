using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Infra.Bank;
namespace Open.Tests.Infra.Bank
{
    [TestClass]
    public class
        AccountRepositoryTests : PaginatedRepositoryTests<Account, AccountData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AccountRepository);
        }
        protected override string getRandomMemberStringValue(AccountData d)
        {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return d.Balance.ToString();
            if (i == 1) return d.AspNetUserId;
            if (i == 2) return d.ID;
            if (i == 3) return d.Status;
            if (i == 4) return d.Type;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<AccountData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 6;
            if (i == 0) return x => x.Balance.ToString();
            if (i == 1) return x => x.AspNetUserId;
            if (i == 2) return x => x.ID;
            if (i == 3) return x => x.Status;
            if (i == 4) return x => x.Type;
            if (i == 5) return x => x.ValidFrom;
            return x => x.ValidTo;
        }
        protected override DbSet<AccountData> getDbSet() => db.Accounts;
        protected override ICrudRepository<Account> getRepository() => new AccountRepository(db);
        protected override Account createObject(AccountData r) => new Account(r);
        protected override AccountData getData(Account o) => o.Data;
        protected override string getID(AccountData r) => r.ID;
        protected override void setRandomValues(Account o)
        {
            o.Data.Balance = GetRandom.Decimal();
            o.Data.Status = GetRandom.String();
            o.Data.Type = GetRandom.String();
            base.setRandomValues(o);
        }
        protected override void validateDbRecords(AccountData e, AccountData a)
        {
            Assert.AreEqual(e.Balance, a.Balance);
            Assert.AreEqual(e.Status, a.Status);
            Assert.AreEqual(e.Type, a.Type);
            base.validateDbRecords(e, a);
        }
        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new AccountRepository(null));
        }
        [TestMethod]
        public void LoadAccountsForUserTest()
        {
            Assert.Inconclusive();
        }
    }
}

