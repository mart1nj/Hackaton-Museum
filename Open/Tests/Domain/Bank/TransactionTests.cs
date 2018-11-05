using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class TransactionTests : EntityBaseTests<Transaction, TransactionData>
    {
        protected override Transaction getRandomObject()
        {
            createdWithNullArg = new Transaction(null);
            dbRecordType = typeof(TransactionData);
            return GetRandom.Object<Transaction>();
        }
        [TestMethod]
        public void SenderAccountTest()
        {
            Assert.AreEqual(obj.SenderAccount.Data, obj.Data.SenderAccount);
        }
        [TestMethod]
        public void ReceiverAccountTest()
        {
            Assert.AreEqual(obj.ReceiverAccount.Data, obj.Data.ReceiverAccount);
        }
        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new Transaction(null);
            Assert.IsNull(obj.Data.SenderAccount);
            Assert.IsNotNull(obj.SenderAccount.Data);
            Assert.IsNull(obj.Data.ReceiverAccount);
            Assert.IsNotNull(obj.ReceiverAccount.Data);
        }
    }
}

