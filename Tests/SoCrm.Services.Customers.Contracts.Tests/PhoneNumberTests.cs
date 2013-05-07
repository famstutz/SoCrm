namespace SoCrm.Services.Customers.Contracts.Tests
{
    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class PhoneNumberTests
    {
        [Test]
        public void Constructor()
        {
            var phoneNumber = new PhoneNumber();

            Assert.IsNotNull(phoneNumber);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var phoneNumber = new PhoneNumber();

            AssertExtensions.IsDefault(phoneNumber.Number);
            AssertExtensions.IsDefault(phoneNumber.ContactType);
        }

        [Test]
        public void SetNumber()
        {
            var phoneNumber = new PhoneNumber();
            var number = "079 839 23 24";
            phoneNumber.Number = number;

            Assert.AreEqual(number, phoneNumber.Number);
        }

        [Test]
        public void SetContactType()
        {
            var phoneNumber = new PhoneNumber();
            var contactType = ContactType.Company;
            phoneNumber.ContactType = contactType;

            Assert.AreEqual(contactType, phoneNumber.ContactType);
        }
    }
}
