using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
namespace Open.Tests.Data.Bank
{
    [TestClass]
    public class ApplicationUserTests : ObjectTests<ApplicationUser>
    {
        class testClass : ApplicationUser { }
        protected override ApplicationUser getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfIdentityUser()
        {
            Assert.AreEqual(typeof(IdentityUser), typeof(ApplicationUser).BaseType);
        }
        [TestMethod]
        public void FirstNameTest()
        {
            canReadWrite(() => obj.FirstName, x => obj.FirstName = x);
        }
        [TestMethod]
        public void LastNameTest()
        {
            canReadWrite(() => obj.LastName, x => obj.LastName = x);
        }
        [TestMethod]
        public void AddressLineTest()
        {
            canReadWrite(() => obj.AddressLine, x => obj.AddressLine = x);
        }
        [TestMethod]
        public void CityTest()
        {
            canReadWrite(() => obj.City, x => obj.City = x);
        }
        [TestMethod]
        public void ZipCodeTest()
        {
            canReadWrite(() => obj.ZipCode, x => obj.ZipCode = x);
        }
        [TestMethod]
        public void CountryTest()
        {
            canReadWrite(() => obj.Country, x => obj.Country = x);
        }
        [TestMethod]
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
        }
    }
}