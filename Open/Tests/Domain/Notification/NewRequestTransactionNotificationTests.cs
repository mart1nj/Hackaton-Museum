using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Tests.Domain.Notification
{
    [TestClass]
    public class NewRequestTransactionNotificationTests : EntityBaseTests<NewRequestTransactionNotification, NewRequestTransactionNotificationData>
    {
        protected override NewRequestTransactionNotification getRandomObject()
        {
            createdWithNullArg = new NewRequestTransactionNotification(null);
            dbRecordType = typeof(NewRequestTransactionNotificationData);
            return GetRandom.Object<NewRequestTransactionNotification>();
        }
    }
}

