using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
using Open.Infra.Notification;
namespace Open.Tests.Infra.Notification
{
    [TestClass]
    public class NotificationsInitializerTests :
        BaseTableInitializerTests<INotification, NotificationData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(NotificationsInitializer);
        }
        protected override ICrudRepository<INotification> getRepository()
            => new NotificationsRepository(db);
        protected override DbSet<NotificationData> getDbSet() => db.Notifications;
        protected override NotificationData getRandomDbRecord()
        {
            var i = GetRandom.Int32() % 3;
            if (i == 0) return GetRandom.Object<NewTransactionNotificationData>();
            if (i == 1) return GetRandom.Object<NewRequestTransactionNotificationData>();
            return GetRandom.Object<WelcomeNotificationData>();
        }
        protected override void initialize() => NotificationsInitializer.Initialize(db);

        protected override void doBeforeCleanup() => clearDbSet(db.TelecomDeviceRegistrations);
    }
}


