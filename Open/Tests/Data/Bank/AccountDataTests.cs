using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Bank;

namespace Open.Tests.Data.Bank {
    [TestClass]
    public class AccountDataTests : ObjectTests<AccountData> {
        class testClass : AccountData { }

        protected override AccountData getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsInstanceOfIdentifiedData() {
            Assert.AreEqual(typeof(IdentifiedData), typeof(AccountData).BaseType);
        }

        [TestMethod]
        public void BalanceTest() {
            canReadWrite(() => obj.Balance, x => obj.Balance = x);
        }

        [TestMethod]
        public void TypeTest() {
            canReadWrite(() => obj.Type, x => obj.Type = x);
        }

        [TestMethod]
        public void StatusTest() {
            canReadWrite(() => obj.Status, x => obj.Status = x);
        }

        [TestMethod]
        public void AspNetUserIdTest() {
            canReadWrite(() => obj.AspNetUserId,
                x => obj.AspNetUserId = x);
        }

        [TestMethod]
        public void AspNetUserTest() {
            canReadWrite(() => obj.AspNetUser,
                x => obj.AspNetUser = x);
        }
    }
}
