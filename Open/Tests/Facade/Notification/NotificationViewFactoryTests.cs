using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class NotificationViewFactoryTests : BaseTests
    {
        private const string u = Constants.Unspecified;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(NotificationViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
            var v = NotificationViewFactory.Create((WelcomeNotification)null) as WelcomeNotificationView;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, u);
            Assert.AreEqual(v.Message, u);
            Assert.AreEqual(v.SenderAccountId, u);
            Assert.AreEqual(v.ReceiverAccountId, u);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.IsSeen, false);
        }
        private void validateCommon(NotificationData d, NotificationView v)
        {
            Assert.AreEqual(v.ID, d.ID);
            Assert.AreEqual(v.ValidFrom, d.ValidFrom);
            Assert.AreEqual(v.ValidTo, d.ValidTo);
            Assert.AreEqual(v.ReceiverAccountId, d.ReceiverId);
            Assert.AreEqual(v.SenderAccountId, d.SenderId);
            Assert.AreEqual(v.Message, d.Message);
            Assert.AreEqual(v.IsSeen, d.IsSeen);
        }
        [TestMethod]
        public void CreateWelcomeNotificationViewTest()
        {
            var o = GetRandom.Object<WelcomeNotification>();
            o.Data.Message = null;
            var v = NotificationViewFactory.Create(o);
            validateCommon(o.Data, v);
        }

        [TestMethod]
        public void CreateNewTransactionNotificationViewTest()
        {
            var o = GetRandom.Object<NewTransactionNotification>();
            var v = NotificationViewFactory.Create(o);
            validateCommon(o.Data, v);
        }
        [TestMethod]
        public void CreateNewRequestTransactionNotificationViewTest()
        {
            var o = GetRandom.Object<NewRequestTransactionNotification>();
            var v = NotificationViewFactory.Create(o);
            validateCommon(o.Data, v);
        }

        [TestMethod]
        public void CreateWithExtremumDatesTest()
        {
            var o = GetRandom.Object<WelcomeNotification>();
            o.Data.ValidFrom = DateTime.MinValue;
            o.Data.ValidTo = DateTime.MaxValue;
            var v = NotificationViewFactory.Create(o);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}
