using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core
{
    [TestClass]
    public class CardTypeTests : ClassTests<CardType>
    {
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, GetEnum.Count<CardType>());
        }

        [TestMethod]
        public void DebitTest() =>
            Assert.AreEqual(0, (int)CardType.Debit);

        [TestMethod]
        public void CreditTest() =>
            Assert.AreEqual(1, (int)CardType.Credit);
        [TestMethod]
        public void VirtualTest() =>
            Assert.AreEqual(2, (int)CardType.Virtual);
    }
}


