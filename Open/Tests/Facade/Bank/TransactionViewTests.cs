using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{

    [TestClass]
    public class TransactionViewTests : ViewTests<TransactionView, EntityView>
    {
        protected override TransactionView getRandomObject()
        {
            return GetRandom.Object<TransactionView>();
        }

        [TestMethod]
        public void AmountTest()
        {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }
        [TestMethod]
        public void ExplanationTest()
        {
            canReadWrite(() => obj.Explanation, x => obj.Explanation = x);
        }
        [TestMethod]
        public void SenderAccountIdTest()
        {
            canReadWrite(() => obj.SenderAccountId, x => obj.SenderAccountId = x);
        }
        [TestMethod]
        public void ReceiverAccountIdTest()
        {
            canReadWrite(() => obj.ReceiverAccountId, x => obj.ReceiverAccountId = x);
        }
        [TestMethod]
        public void ValidFromTest()
        {
            canReadWrite(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        [TestMethod]
        public void SenderAccountTest()
        {
            canReadWrite(() => obj.SenderAccount, x => obj.SenderAccount = x);
        }
        [TestMethod]
        public void ReceiverAccountTest()
        {
            canReadWrite(() => obj.ReceiverAccount, x => obj.ReceiverAccount = x);
        }
    }
}

