using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
using Open.Facade.Notification;
using Open.Infra.Notification;
namespace Open.Tests.Infra.Notification
{
    [TestClass]
    public class NotificationsRepositoryTests : PaginatedRepositoryTests<INotification, NotificationData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(NotificationsRepository);
        }
        protected override string getRandomMemberStringValue(NotificationData d)
        {
            var i = GetRandom.UInt32() % 4;
            if (i == 0) return d.Message;
            if (i == 1) return d.ReceiverId;
            if (i == 2) return d.SenderId;
            if (i == 3) return d.ID;
            return base.getRandomMemberStringValue(d);
        }
        protected override Func<NotificationData, object> getRandomSortFunction()
        {
            return x => x.ValidFrom;
        }
        protected override INotification createObject(NotificationData r) => NotificationFactory.Create(r);
        protected override string getID(NotificationData r) => r.ID;
        protected override ICrudRepository<INotification> getRepository() => new NotificationsRepository(db);
        protected override DbSet<NotificationData> getDbSet() => db.Notifications;
        protected override NotificationData getData(INotification o)
        {
            switch (o)
            {
                case NewTransactionNotification transaction: return transaction.Data;
                case NewRequestTransactionNotification request: return request.Data;
                default: return (o as WelcomeNotification)?.Data;
            }
        }
        protected override NotificationData getRandomDbRecord()
        {
            var i = GetRandom.Int32() % 3;
            if (i == 0) return GetRandom.Object<NewTransactionNotificationData>();
            if (i == 1) return GetRandom.Object<NewRequestTransactionNotificationData>();
            return GetRandom.Object<WelcomeNotificationData>();
        }
        protected override void validateDbRecords(NotificationData e, NotificationData a)
        {
            var eObj = NotificationFactory.Create(e);
            var aObj = NotificationFactory.Create(a);
            var eView = NotificationViewFactory.Create(eObj);
            var aView = NotificationViewFactory.Create(aObj);
            Assert.AreEqual(eView.FormattedMessage, aView.FormattedMessage);
            base.validateDbRecords(e, a);
        }

        [TestMethod]
        public void LoadNotificationsForAllUsersTest()
        {
            Assert.Inconclusive();
        }
    }
}


