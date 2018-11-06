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
    public class TransactionsInitializerTests :
        BaseTableInitializerTests<Transaction, TransactionData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TransactionsInitializer);
        }
        protected override ICrudRepository<Transaction> getRepository()
            => new TransactionRepository(db);
        protected override DbSet<TransactionData> getDbSet() => db.Transactions;
        protected override TransactionData getRandomDbRecord()
        {
            return GetRandom.Object<TransactionData>();
        }
        protected override void initialize() => TransactionsInitializer.Initialize(db);

        protected override void doBeforeCleanup() => clearDbSet(db.Transactions);
    }
}



