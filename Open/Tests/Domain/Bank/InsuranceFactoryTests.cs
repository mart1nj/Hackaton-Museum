using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class InsuranceFactoryTests : BaseTests
    {
        private string id;
        private decimal payment;
        private string status;
        private string typeA;
        private string accountId;
        private DateTime validFrom;
        private DateTime validTo;
        private Insurance o;
        
        private void initializeTestData()
        {
            var min = DateTime.Now.AddYears(-50);
            var max = DateTime.Now.AddYears(50);
            id = GetRandom.String();
            payment = GetRandom.Decimal();
            status = GetRandom.String();
            accountId = GetRandom.String();
            typeA = GetRandom.String();
            validFrom = GetRandom.DateTime(min, max);
            validTo = GetRandom.DateTime(validFrom, max);
        }
        private void validateResults(string i = Constants.Unspecified,
            decimal? a = 0, string e = Constants.Unspecified, string s = Constants.Unspecified,
            string r = Constants.Unspecified, DateTime? f = null, DateTime? t = null)
        {
            Assert.AreEqual(i, o.Data.ID);
            Assert.AreEqual(a, o.Data.Payment);
            Assert.AreEqual(e, o.Data.Status);
            Assert.AreEqual(s, o.Data.Type);
            Assert.AreEqual(r, o.Data.AccountId);
            Assert.AreEqual(f ?? DateTime.MinValue, o.Data.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, o.Data.ValidTo);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(InsuranceFactory);
            initializeTestData();
        }
        [TestMethod]
        public void CreateInsuranceTest()
        {
            o = InsuranceFactory.CreateInsurance(id, payment, typeA, status, accountId, validFrom, validTo);
            validateResults(id, payment, status, typeA, accountId, validFrom, validTo);
        }
    }
}


