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
    public class InsuranceRepositoryTests : PaginatedRepositoryTests<Insurance, InsuranceData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(InsuranceRepository);
        }
        protected override string getRandomMemberStringValue(InsuranceData d)
        {
            var i = GetRandom.UInt32() % 5;
            if (i == 0) return d.Payment.ToString();
            if (i == 1) return d.AccountId;
            if (i == 2) return d.Status;
            if (i == 3) return d.ID;
            if (i == 4) return d.Type;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<InsuranceData, object> getRandomSortFunction()
        {
            var i = GetRandom.UInt32() % 7;
            if (i == 0) return x => x.Payment.ToString();
            if (i == 1) return x => x.AccountId;
            if (i == 2) return x => x.Status;
            if (i == 3) return x => x.ID;
            if (i == 4) return x => x.Type;
            if (i == 5) return x => x.ValidTo;
            if (i == 6) return x => x.ValidFrom;
            return x => x.ValidFrom;
        }
        protected override DbSet<InsuranceData> getDbSet() => db.Insurances;
        protected override ICrudRepository<Insurance> getRepository() => new InsuranceRepository(db);
        protected override Insurance createObject(InsuranceData r) => new Insurance(r);
        protected override InsuranceData getData(Insurance o) => o.Data;
        protected override string getID(InsuranceData r) => r.ID;
        protected override void setRandomValues(Insurance o)
        {
            o.Data.Payment = GetRandom.Decimal();
            o.Data.Type = GetRandom.String();
            base.setRandomValues(o);
        }
        protected override void validateDbRecords(InsuranceData e, InsuranceData a)
        {
            Assert.AreEqual(e.Payment, a.Payment);
            Assert.AreEqual(e.Type, a.Type);
            base.validateDbRecords(e, a);
        }
        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new InsuranceRepository(null));
        }
        [TestMethod] public void LoadInsurancesForUserTest() {
            Assert.Inconclusive();
        }
    }
}
