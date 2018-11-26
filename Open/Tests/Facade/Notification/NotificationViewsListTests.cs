using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class NotificationViewsListTests : ObjectTests<NotificationViewsList>
    {
        protected override NotificationViewsList getRandomObject()
        {
            var l = new NotificationsList(getRandomNotificationDbRecordsList(),
                GetRandom.Object<RepositoryPage>());
            SetRandom.Values(l);
            return new NotificationViewsList(l);
        }
        private IEnumerable<NotificationData> getRandomNotificationDbRecordsList()
        {
            var l = new List<NotificationData>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++)
            {
                var x = i % 3;
                if (x == 0) l.Add(GetRandom.Object<WelcomeNotificationData>());
                if (x == 1) l.Add(GetRandom.Object<NewTransactionNotificationData>());
                if (x == 2) l.Add(GetRandom.Object<NewRequestTransactionNotificationData>());
            }

            return l;
        }
        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new NotificationViewsList(null));
        }

    }
}
