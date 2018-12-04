using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class StatusTests : ClassTests<TransactionStatus>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, GetEnum.Count<TransactionStatus>());
        }

        [TestMethod]
        public void PendingTest() =>
            Assert.AreEqual(0, (int)TransactionStatus.Pending);

        [TestMethod]
        public void DeniedTest() =>
            Assert.AreEqual(1, (int)TransactionStatus.Denied);
        [TestMethod]
        public void ConfirmedTest() =>
            Assert.AreEqual(2, (int)TransactionStatus.Confirmed);
    }
}


