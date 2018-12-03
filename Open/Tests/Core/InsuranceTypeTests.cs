using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class InsuranceTypeTests : ClassTests<InsuranceType>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(4, GetEnum.Count<InsuranceType>());
        }

        [TestMethod]
        public void HomeTest() =>
            Assert.AreEqual(0, (int)InsuranceType.Home);

        [TestMethod]
        public void CarTest() =>
            Assert.AreEqual(1, (int)InsuranceType.Car);
        
        [TestMethod]
        public void HealthTest() =>
            Assert.AreEqual(2, (int)InsuranceType.Health);
        
        [TestMethod]
        public void TravelTest() =>
            Assert.AreEqual(3, (int)InsuranceType.Travel);
    }
}
