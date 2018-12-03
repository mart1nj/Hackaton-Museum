using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Bank;
using Open.Facade.Bank;
namespace Open.Tests.Facade.Bank
{
        [TestClass]
        public class InsuranceViewsListTests : ObjectTests<InsuranceViewsList>
        {
            protected override InsuranceViewsList getRandomObject()
            {
                var l = new InsuranceList(null, null);
                SetRandom.Values(l);
                return new InsuranceViewsList(l);
            }

            [TestMethod]
            public void CanCreateWithNullArgumentTest()
            {
                Assert.IsNotNull(new InsuranceViewsList(null));
            }

        }
}
