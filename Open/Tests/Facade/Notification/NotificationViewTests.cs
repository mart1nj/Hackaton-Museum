using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class NotificationViewTests : ObjectTests<NotificationView>
    {

        private class testClass : NotificationView { }

        protected override NotificationView getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsUniqueEntityViewModelTest()
        {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(EntityView));
        }
        [TestMethod]
        public void MessageTest()
        {
            canReadWrite(() => obj.Message, x => obj.Message = x);
        }
        [TestMethod]
        public void SenderAccountIdTest()
        {
            canReadWrite(() => obj.SenderAccountId, x => obj.SenderAccountId = x);
        }
        [TestMethod]
        public void ReceiverAccountIdTest()
        {
            canReadWrite(() => obj.ReceiverAccountId, x => obj.ReceiverAccountId = x);
        }
        [TestMethod]
        public void IsSeenTest()
        {
            canReadWrite(() => obj.IsSeen, x => obj.IsSeen = x);
        }
        [TestMethod]
        public void ValidFromTest()
        {
            canReadWrite(() => obj.ValidFrom, x => obj.ValidFrom = x);
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
        [TestMethod]
        public void NotificationTypeTest()
        {
            Assert.AreEqual("testClass", obj.NotificationType);
            Assert.AreEqual("Welcome", new WelcomeNotificationView().NotificationType);
            Assert.AreEqual("NewTransaction", new NewTransactionNotificationView().NotificationType);
            Assert.AreEqual("NewRequestTransaction", new NewRequestTransactionNotificationView().NotificationType);
        }
        [TestMethod]
        public void FormattedMessageTest()
        {
            Assert.AreEqual(obj.FormattedMessage, obj.ToString());
        }
    }
}


