using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Tests.Domain.Notification
{
    [TestClass]
    public class NotificationTests : EntityBaseTests<Notification<WelcomeNotificationData>,
        WelcomeNotificationData>
    {
        class testClass : Notification<WelcomeNotificationData>
        {
            public testClass(WelcomeNotificationData r) : base(r) { }
        }
        protected override Notification<WelcomeNotificationData> getRandomObject()
        {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(WelcomeNotificationData);
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsIAddressObjectTest()
        {
            Assert.IsInstanceOfType(obj, typeof(INotification));
        }
        [TestMethod]
        public void SenderTest()
        {
            Assert.AreEqual(obj.Sender.Data, obj.Data.Sender);
        }
        [TestMethod]
        public void ReceiverTest()
        {
            Assert.AreEqual(obj.Receiver.Data, obj.Data.Receiver);
        }
        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new WelcomeNotification(null);
            Assert.IsNull(obj.Data.Sender);
            Assert.IsNull(obj.Data.Receiver);
            Assert.IsNotNull(obj.Sender.Data);
            Assert.IsNotNull(obj.Receiver.Data);
        }
    }
}


