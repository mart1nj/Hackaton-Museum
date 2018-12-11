using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class NewRequestTransactionNotificationViewTests : ObjectTests<NewRequestTransactionNotificationView>
    {
        protected override NewRequestTransactionNotificationView getRandomObject()
        {
            return GetRandom.Object<NewRequestTransactionNotificationView>();
        }
        [TestMethod]
        public void IsNewTransactionNotificationViewTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(NewTransactionNotificationView));
        }
    }
}


