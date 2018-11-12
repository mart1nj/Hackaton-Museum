using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{
    [TestClass]
    public class AccountViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AccountViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<AccountData>();
            var o = new Account(r);
            var v = AccountViewFactory.Create(o);
            Assert.AreEqual(v.Type, o.Data.Type);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.Status, o.Data.Status);
            Assert.AreEqual(v.Balance, o.Data.Balance);
            Assert.AreEqual(v.AspNetUserId, o.Data.AspNetUserId);
        }
    }
}