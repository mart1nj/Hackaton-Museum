using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Tests.Domain.Notification
{
    [TestClass]
    public class WelcomeNotificationTests : EntityBaseTests<WelcomeNotification, WelcomeNotificationData>
    {
        protected override WelcomeNotification getRandomObject()
        {
            createdWithNullArg = new WelcomeNotification(null);
            dbRecordType = typeof(WelcomeNotificationData);
            return GetRandom.Object<WelcomeNotification>();
        }
    }
}

