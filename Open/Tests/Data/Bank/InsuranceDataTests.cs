using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Data.Common;
namespace Open.Tests.Data.Bank
{
    [TestClass]
    public class InsuranceDataTests : ObjectTests<InsuranceData>
    {
        class testClass : InsuranceData { }
        protected override InsuranceData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfIdentityUser()
        {
            Assert.AreEqual(typeof(IdentifiedData), typeof(InsuranceData).BaseType);
        }
        [TestMethod]
        public void PaymentTest()
        {
            canReadWrite(() => obj.Payment, x => obj.Payment = x);
        }
        [TestMethod]
        public void TypeTest()
        {
            canReadWrite(() => obj.Type, x => obj.Type= x);
        }
        [TestMethod]
        public void StatusTest()
        {
            canReadWrite(() => obj.Status, x => obj.Status = x);
        }
        [TestMethod]
        public void AccountIdTest()
        {
            canReadWrite(() => obj.AccountId, x => obj.AccountId = x);
        }
        [TestMethod]
        public void AccountTest()
        {
            canReadWrite(() => obj.Account, x => obj.Account = x);
        }
    }
}
