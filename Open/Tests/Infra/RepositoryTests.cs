using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Infra;
namespace Open.Tests.Infra
{

    public class RepositoryTests: BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(Repository<Account, AccountData>);
        }
        [TestMethod] public void IsInitializedTest() {
            Assert.Inconclusive();
        }
    }
}


