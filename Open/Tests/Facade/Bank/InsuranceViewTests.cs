
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Bank;
using Open.Facade.Common;
namespace Open.Tests.Facade.Bank
{

    [TestClass]
    public class InsuranceViewTests : ViewTests<InsuranceView, EntityView> {

        protected override InsuranceView getRandomObject()
        {
            return GetRandom.Object<InsuranceView>();
        }
        
        [TestMethod]
        public void PaymentInStringFormatTest() {
            var str = obj.PaymentInStringFormat;
            Assert.AreEqual(str, obj.PaymentInStringFormat);
            var rnd = GetRandom.String();
            obj.PaymentInStringFormat = rnd;
            Assert.AreEqual(rnd, obj.PaymentInStringFormat);
        }
        [TestMethod]
        public void PaymentTest()
        {
            Assert.AreEqual(obj.PaymentInStringFormat, obj.Payment.ToString());
        }
        [TestMethod]
        public void StatusTest()
        {
            canReadWrite(() => obj.Status, x => obj.Status = x);
        }
        [TestMethod]
        public void TypeTest()
        {
            canReadWrite(() => obj.Type, x => obj.Type = x);
        }
        [TestMethod]
        public void AccountIdTest()
        {
            canReadWrite(() => obj.AccountId, x => obj.AccountId = x);
        }
 
        [TestMethod]
        public void ValidFromTest()
        {
            canReadWrite(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        
        [TestMethod]
        public void ValidToTest()
        {
            canReadWrite(() => obj.ValidTo, x => obj.ValidTo = x);
        }
        [TestMethod]
        public void AccountTest()
        {
            canReadWrite(() => obj.Account, x => obj.Account = x);
        }
    }
}

