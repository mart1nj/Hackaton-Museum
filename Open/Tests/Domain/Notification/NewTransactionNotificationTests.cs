using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Tests.Domain.Notification
{
    [TestClass]
    public class NewTransactionNotificationTests : EntityBaseTests<NewTransactionNotification, NewTransactionNotificationData>
    {
        protected override NewTransactionNotification getRandomObject()
        {
            createdWithNullArg = new NewTransactionNotification(null);
            dbRecordType = typeof(NewTransactionNotificationData);
            return GetRandom.Object<NewTransactionNotification>();
        }
    }
}

