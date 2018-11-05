using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass] public class PeriodTests : EntityBaseTests<Period<AccountData> , AccountData> {
        class testClass : Period<AccountData> {
            public testClass(AccountData dbRecord) : base(dbRecord) { }
        }
        protected override Period<AccountData> getRandomObject() {
            dbRecordType = typeof(PeriodData);
            createdWithNullArg = new testClass(null);
            return GetRandom.Object<testClass>();
        }
    }
}

