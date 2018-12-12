using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids.Extensions;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class LinqExtensionsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(LinqExtensions);
        }

        [TestMethod] public void DistinctByTest() {
            //TODO: Assert.Inconclusive("Don't know what it does");
        }

        [TestMethod] public void FlattenTest() {
            //TODO: Assert.Inconclusive("Don't know what it does");
        }

        [TestMethod] public void IsGroupedTest() {
            //TODO: Assert.Inconclusive("Don't know what it does");
        }
    }
}
