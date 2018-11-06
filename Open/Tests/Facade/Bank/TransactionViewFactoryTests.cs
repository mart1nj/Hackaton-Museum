using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{
    [TestClass]
    public class TransactionViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TransactionViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<TransactionData>();
            var o = new Transaction(r);
            var v = TransactionViewFactory.Create(o);
            Assert.AreEqual(v.Amount, o.Data.Amount);
            Assert.AreEqual(v.Explanation, o.Data.Explanation);
            Assert.AreEqual(v.SenderAccountId, o.Data.SenderAccountId);
            Assert.AreEqual(v.ReceiverAccountId, o.Data.ReceiverAccountId);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
        }
    }
}