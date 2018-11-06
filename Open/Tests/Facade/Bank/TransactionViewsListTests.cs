using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{

    [TestClass]
    public class TransactionViewsListTests : ObjectTests<TransactionViewsList>
    {
        protected override TransactionViewsList getRandomObject()
        {
            var l = new TransactionList(null, null);
            SetRandom.Values(l);
            return new TransactionViewsList(l);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new TransactionViewsList(null));
        }

    }
}