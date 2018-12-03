
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{
    [TestClass]
    public class InsuranceViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(InsuranceViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<InsuranceData>();
            var o = new Insurance(r);
            var v = InsuranceViewFactory.Create(o);
            Assert.AreEqual(v.Payment, o.Data.Payment);
            Assert.AreEqual(v.Status, o.Data.Status);
            Assert.AreEqual(v.Type, o.Data.Type);
            Assert.AreEqual(v.AccountId, o.Data.AccountId);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
        }
    }
}