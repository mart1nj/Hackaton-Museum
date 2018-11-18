using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class AccountFactoryTests : BaseTests
    {
        private string id;
        private decimal? balance;
        private string accountType;
        private string status;
        private string aspNetUserId;
        private DateTime validFrom;
        private DateTime validTo;
        private Account o;
        private void initializeTestData()
        {
            var min = DateTime.Now.AddYears(-50);
            var max = DateTime.Now.AddYears(50);
            id = GetRandom.String();
            balance = GetRandom.Decimal();
            accountType = GetRandom.String();
            status = GetRandom.String();
            aspNetUserId = GetRandom.String();
            validFrom = GetRandom.DateTime(min, max);
            validTo = GetRandom.DateTime(validFrom, max);
        }
        private void validateResults(string i = Constants.Unspecified,
            decimal? b = 0, string ty = Constants.Unspecified, string s = Constants.Unspecified,
            string a = Constants.Unspecified, DateTime? f = null, DateTime? t = null)
        {
            Assert.AreEqual(i, o.Data.ID);
            Assert.AreEqual(b, o.Data.Balance);
            Assert.AreEqual(ty, o.Data.Type);
            Assert.AreEqual(s, o.Data.Status);
            Assert.AreEqual(a, o.Data.AspNetUserId);
            Assert.AreEqual(f ?? DateTime.MinValue, o.Data.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, o.Data.ValidTo);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AccountFactory);
            initializeTestData();
        }
        [TestMethod]
        public void CreateAccountTest()
        {
            o = AccountFactory.CreateAccount(id, balance, accountType, status, aspNetUserId, validFrom, validTo);
            validateResults(id, balance, accountType, status, aspNetUserId, validFrom, validTo);
        }
    }
}


