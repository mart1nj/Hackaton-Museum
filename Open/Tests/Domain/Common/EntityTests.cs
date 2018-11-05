using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass]
    public class
        EntityTests : EntityBaseTests<Entity<AccountData>, AccountData> {
        class testClass : Entity<AccountData> {
            public testClass(AccountData dbRecord) : base(dbRecord) { }
        }
        protected override Entity<AccountData> getRandomObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(IdentifiedData);
            return GetRandom.Object<testClass>();
        }

    }
}



