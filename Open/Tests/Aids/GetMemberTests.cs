using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Aids {
    [TestClass] public class GetMemberTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetMember);
        }

        [TestMethod] public void NameTest() {
            Assert.AreEqual("Data", GetMember.Name<Account>(o => o.Data));
            Assert.AreEqual("Balance", GetMember.Name<AccountData>(o => o.Balance));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<AccountData, object>>)null));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Action<AccountData>>)null));
        }
        [TestMethod] public void DisplayNameTest() {
            Assert.AreEqual("Data", GetMember.DisplayName<Account>(o => o.Data));
            Assert.AreEqual("Valid From",
                GetMember.DisplayName<AccountView>(o => o.ValidFrom));
            Assert.AreEqual("Balance", GetMember.DisplayName<AccountView>(o => o.Balance));
            Assert.AreEqual("Valid To", GetMember.DisplayName<AccountView>(o => o.ValidTo));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<AccountView>(null));
            //Impossible to use for methods
            //Assert.AreEqual(string.Empty, GetMember.DisplayName<GetMemberTests>(o => o.NameTest()));
        }
    }
}


