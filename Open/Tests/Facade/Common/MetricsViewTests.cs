using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
namespace Open.Tests.Facade.Common {
    [TestClass] public class MetricsViewTests : ObjectTests<MetricsView> {
        protected override MetricsView getRandomObject() {
            return GetRandom.Object<MetricsView>();
        }

        [TestMethod] public void IsNamedViewTest() {
            Assert.AreEqual(typeof(NamedView), obj.GetType().BaseType);
        }
        [TestMethod] public void IDTest() {
            canReadWrite(() => obj.ID, x => obj.ID = x);
        }
        [TestMethod] public void CodeTest() {
            canReadWrite(() => obj.Code, x => obj.Code = x);
        }
        [TestMethod] public void DefinitionTest() {
            canReadWrite(() => obj.Definition, x => obj.Definition = x);
        }
    }
}
