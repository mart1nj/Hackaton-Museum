using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class AccountTests : EntityBaseTests<Account, AccountData>
    {
        protected override Account getRandomObject()
        {
            createdWithNullArg = new Account(null);
            dbRecordType = typeof(AccountData);
            return GetRandom.Object<Account>();
        }
        [TestMethod]
        public void ApplicationUserTest()
        {
            Assert.AreEqual(obj.ApplicationUser, obj.Data.AspNetUser);
        }
    }
}

