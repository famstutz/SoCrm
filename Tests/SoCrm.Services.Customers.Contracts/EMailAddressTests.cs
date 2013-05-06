namespace SoCrm.Services.Customers.Contracts
{
    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class EMailAddressTests
    {
        [Test]
        public void Constructor()
        {
            var emailAddress = new EMailAddress();

            Assert.IsNotNull(emailAddress);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var emailAddress = new EMailAddress();

            AssertExtensions.IsDefault(emailAddress.Address);
            AssertExtensions.IsDefault(emailAddress.ContactType);
        }

        [Test]
        public void SetAddress()
        {
            var emailAddress = new EMailAddress();
            var address = "peter@muster.ch";
            emailAddress.Address = address;

            Assert.AreEqual(address, emailAddress.Address);
        }

        [Test]
        public void SetContactType()
        {
            var emailAddress = new EMailAddress();
            var contactType = ContactType.Company;
            emailAddress.ContactType = contactType;

            Assert.AreEqual(contactType, emailAddress.ContactType);
        }
    }
}
