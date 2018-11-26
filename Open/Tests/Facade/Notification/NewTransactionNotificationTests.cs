using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class NewTransactionNotificationViewTests : ObjectTests<NewTransactionNotificationView>
    {

        protected override NewTransactionNotificationView getRandomObject()
        {
            return GetRandom.Object<NewTransactionNotificationView>();
        }

        [TestMethod]
        public void IsNotificationViewTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(NotificationView));
        }

        [TestMethod]
        public void AmountTest()
        {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }
        [TestMethod]
        public void ToStringTest()
        {
            var s =  $"{obj.SenderAccountId} {obj.Message} {obj.Amount}. ";
            Assert.AreEqual(s, obj.ToString());
        }

    }
}






