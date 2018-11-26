using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels
{
    [TestClass]
    public class IndexViewModelTests : ObjectTests<IndexViewModel>
    {


        [TestMethod] public void UsernameTest() {
            isNullableReadWriteStringProperty(() => obj.Username, x => obj.Username = x);
            hasAttributes(o => o.Username);
        }

        [TestMethod] public void IsEmailConfirmedTest() {
            canReadWrite(() => obj.IsEmailConfirmed, x => obj.IsEmailConfirmed = x);
            hasAttributes(o => o.IsEmailConfirmed);
        }

        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PhoneNumberTest() {
            isNullableReadWriteStringProperty(() => obj.PhoneNumber, x => obj.PhoneNumber = x);
            hasAttributes(o => o.PhoneNumber, typeof(DisplayAttribute), typeof(PhoneAttribute));
        }

        [TestMethod] public void StatusMessageTest() {
            isNullableReadWriteStringProperty(() => obj.StatusMessage, x => obj.StatusMessage = x);
            hasAttributes(o => o.StatusMessage);
        }

        protected override IndexViewModel getRandomObject() => GetRandom.Object<IndexViewModel>();

        [TestMethod]
        public void FirstNameTest()
        {
            isNullableReadWriteStringProperty(() => obj.FirstName, x => obj.FirstName = x);
            hasAttributes(o => o.FirstName, typeof(DisplayAttribute));
        }

        [TestMethod]
        public void LastNameTest()
        {
            isNullableReadWriteStringProperty(() => obj.LastName, x => obj.LastName = x);
            hasAttributes(o => o.LastName, typeof(DisplayAttribute));
        }
        [TestMethod]
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
            hasAttributes(o => o.DateOfBirth, typeof(DisplayAttribute),
                typeof(DataTypeAttribute));
        }
        [TestMethod]
        public void AddressLineTest()
        {
            isNullableReadWriteStringProperty(() => obj.AddressLine, x => obj.AddressLine = x);
            hasAttributes(o => o.AddressLine, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }

        [TestMethod]
        public void CityTest()
        {
            isNullableReadWriteStringProperty(() => obj.City, x => obj.City = x);
            hasAttributes(o => o.City, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }
        [TestMethod]
        public void ZipCodeTest()
        {
            isNullableReadWriteStringProperty(() => obj.ZipCode, x => obj.ZipCode = x);
            hasAttributes(o => o.ZipCode, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }

        [TestMethod]
        public void CountryTest()
        {
            isNullableReadWriteStringProperty(() => obj.Country, x => obj.Country = x);
            hasAttributes(o => o.Country, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }
        [TestMethod]
        public void CountyTest()
        {
            isNullableReadWriteStringProperty(() => obj.County, x => obj.County = x);
            hasAttributes(o => o.County, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }
    }
}
