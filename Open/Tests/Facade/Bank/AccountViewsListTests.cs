using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{

    [TestClass]
    public class AccountsViewsListTests : ObjectTests<AccountsViewsList>
    {
        protected override AccountsViewsList getRandomObject()
        {
            var l = new AccountList(null, null);
            SetRandom.Values(l);
            return new AccountsViewsList(l);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new AccountsViewsList(null));
        }

    }
}



