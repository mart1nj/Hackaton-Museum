using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Notification;
namespace Open.Tests.Data.Notification
{
    [TestClass]
    public class NotificationDataTests : ObjectTests<NotificationData>
    {
        class testClass : NotificationData { }
        protected override NotificationData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfIdentityUser()
        {
            Assert.AreEqual(typeof(IdentifiedData), typeof(NotificationData).BaseType);
        }
        [TestMethod]
        public void MessageTest()
        {
            canReadWrite(() => obj.Message, x => obj.Message = x);
        }
        [TestMethod]
        public void SenderIdTest()
        {
            canReadWrite(() => obj.SenderId, x => obj.SenderId = x);
        }
        [TestMethod]
        public void ReceiverIdTest()
        {
            canReadWrite(() => obj.ReceiverId, x => obj.ReceiverId = x);
        }
        [TestMethod]
        public void IsSeenTest()
        {
            canReadWrite(() => obj.IsSeen, x => obj.IsSeen = x);
        }
        [TestMethod]
        public void SenderTest()
        {
            canReadWrite(() => obj.Sender, x => obj.Sender = x);
        }
        [TestMethod]
        public void ReceiverTest()
        {
            canReadWrite(() => obj.Receiver, x => obj.Receiver = x);
        }
    }
}