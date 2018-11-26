using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Models.AccountViewModels {
    [TestClass] public class RegisterViewModelTests : ObjectTests<RegisterViewModel> {
        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PasswordTest() {
            isNullableReadWriteStringProperty(() => obj.Password, x => obj.Password = x);
            hasAttributes(o => o.Password, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(DataTypeAttribute), typeof(StringLengthAttribute));
        }

        [TestMethod] public void ConfirmPasswordTest() {
            isNullableReadWriteStringProperty(() => obj.ConfirmPassword,
                x => obj.ConfirmPassword = x);
            hasAttributes(o => o.ConfirmPassword, typeof(CompareAttribute),
                typeof(DisplayAttribute), typeof(DataTypeAttribute));
        }

        protected override RegisterViewModel getRandomObject() =>
            GetRandom.Object<RegisterViewModel>();

        [TestMethod]
        public void FirstNameTest()
        {
            isNullableReadWriteStringProperty(() => obj.FirstName, x => obj.FirstName = x);
            hasAttributes(o => o.FirstName, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }

        [TestMethod]
        public void LastNameTest()
        {
            isNullableReadWriteStringProperty(() => obj.LastName, x => obj.LastName = x);
            hasAttributes(o => o.LastName, typeof(RequiredAttribute), typeof(DisplayAttribute));
        }
        [TestMethod]
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
            hasAttributes(o => o.DateOfBirth, typeof(RequiredAttribute), typeof(DisplayAttribute),
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
