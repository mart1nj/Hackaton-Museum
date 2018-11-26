using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Tests.Domain.Notification
{
    [TestClass]
    public class NotificationsListTests : ListBaseTests<NotificationsList, INotification>
    {
        protected override NotificationsList getRandomObject()
        {
            createWithNullArgs = new NotificationsList(null, null);
            var l = getRandomAddressDbRecordsList();
            return new NotificationsList(l, GetRandom.Object<RepositoryPage>());
        }
        internal static IEnumerable<NotificationData> getRandomAddressDbRecordsList()
        {
            var l = new List<NotificationData>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++)
            {
                l.Add(getRandomNotificationDbRecord(i));
            }

            return l;
        }
        internal static NotificationData getRandomNotificationDbRecord(int i = int.MinValue)
        {
            i = i == int.MinValue ? GetRandom.UInt8() : i;
            var x = i % 3;
            if (x == 0) return GetRandom.Object<NewTransactionNotificationData>();
            if (x == 1) return GetRandom.Object<NewRequestTransactionNotificationData>();
            return GetRandom.Object<WelcomeNotificationData>();
        }
    }
}

