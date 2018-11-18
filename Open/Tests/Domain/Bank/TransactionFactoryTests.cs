using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class TransactionFactoryTests : BaseTests
    {
        private string id;
        private decimal amount;
        private string explanation;
        private string senderAccountId;
        private string receiverAccountId;
        private DateTime validFrom;
        private DateTime validTo;
        private Transaction o;
        private void initializeTestData()
        {
            var min = DateTime.Now.AddYears(-50);
            var max = DateTime.Now.AddYears(50);
            id = GetRandom.String();
            amount = GetRandom.Decimal();
            explanation = GetRandom.String();
            senderAccountId = GetRandom.String();
            receiverAccountId = GetRandom.String();
            validFrom = GetRandom.DateTime(min, max);
            validTo = GetRandom.DateTime(validFrom, max);
        }
        private void validateResults(string i = Constants.Unspecified,
            decimal? a = 0, string e = Constants.Unspecified, string s = Constants.Unspecified,
            string r = Constants.Unspecified, DateTime? f = null, DateTime? t = null)
        {
            Assert.AreEqual(i, o.Data.ID);
            Assert.AreEqual(a, o.Data.Amount);
            Assert.AreEqual(e, o.Data.Explanation);
            Assert.AreEqual(s, o.Data.SenderAccountId);
            Assert.AreEqual(r, o.Data.ReceiverAccountId);
            Assert.AreEqual(f ?? DateTime.MinValue, o.Data.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, o.Data.ValidTo);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TransactionFactory);
            initializeTestData();
        }
        [TestMethod]
        public void CreateTransactionTest()
        {
            o = TransactionFactory.CreateTransaction(id, amount, explanation, senderAccountId, receiverAccountId, validFrom, validTo);
            validateResults(id, amount, explanation, senderAccountId, receiverAccountId, validFrom, validTo);
        }
    }
}


