using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Bank;

namespace Open.Tests.Facade.Bank {
    [TestClass]
    public class AccountViewTests : ViewTests<AccountView, EntityView> {
        protected override AccountView getRandomObject() {
            return GetRandom.Object<AccountView>();
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
            canReadWrite(() => obj.AspNetUserId, x => obj.AspNetUserId = x);
        }

        [TestMethod]
        public void AspNetUserTest() {
            canReadWrite(() => obj.AspNetUser, x => obj.AspNetUser = x);
        }
    }
}
