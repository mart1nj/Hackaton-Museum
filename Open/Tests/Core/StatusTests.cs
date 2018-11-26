using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class StatusTests : ClassTests<Status>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, GetEnum.Count<Status>());
        }

        [TestMethod]
        public void PendingTest() =>
            Assert.AreEqual(0, (int)Status.Pending);

        [TestMethod]
        public void DeniedTest() =>
            Assert.AreEqual(1, (int)Status.Denied);
        [TestMethod]
        public void ConfirmedTest() =>
            Assert.AreEqual(2, (int)Status.Confirmed);
    }
}


