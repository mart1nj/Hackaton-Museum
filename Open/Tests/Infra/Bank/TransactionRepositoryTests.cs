using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Infra.Bank;
namespace Open.Tests.Infra.Bank
{
    [TestClass]
    public class
        TransactionRepositoryTests : PaginatedRepositoryTests<Transaction, TransactionData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TransactionRepository);
        }
        protected override string getRandomMemberStringValue(TransactionData d)
        {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return d.Amount.ToString();
            if (i == 1) return d.SenderAccountId;
            if (i == 2) return d.ReceiverAccountId;
            if (i == 3) return d.ID;
            if (i == 4) return d.Explanation;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<TransactionData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 6;
            if (i == 0) return x => x.Amount.ToString();
            if (i == 1) return x => x.SenderAccountId;
            if (i == 2) return x => x.ReceiverAccountId;
            if (i == 3) return x => x.ID;
            if (i == 4) return x => x.Explanation;
            if (i == 5) return x => x.ValidTo;
            return x => x.ValidFrom;
        }
        protected override DbSet<TransactionData> getDbSet() => db.Transactions;
        protected override ICrudRepository<Transaction> getRepository() => new TransactionRepository(db);
        protected override Transaction createObject(TransactionData r) => new Transaction(r);
        protected override TransactionData getData(Transaction o) => o.Data;
        protected override string getID(TransactionData r) => r.ID;
        protected override void setRandomValues(Transaction o)
        {
            o.Data.Amount = GetRandom.Decimal();
            o.Data.Explanation = GetRandom.String();
            base.setRandomValues(o);
        }
        protected override void validateDbRecords(TransactionData e, TransactionData a)
        {
            Assert.AreEqual(e.Amount, a.Amount);
            Assert.AreEqual(e.Explanation, a.Explanation);
            base.validateDbRecords(e, a);
        }
        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new TransactionRepository(null));
        }
        [TestMethod] public void LoadTransactionsForAccountTest() {
            Assert.Inconclusive();
        }
    }
}


