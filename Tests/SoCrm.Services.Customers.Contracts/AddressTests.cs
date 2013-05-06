namespace SoCrm.Services.Customers.Contracts
{
    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void Constructor()
        {
            var address = new Address();

            Assert.IsNotNull(address);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var address = new Address();

            AssertExtensions.IsDefault(address.AddressLine);
            AssertExtensions.IsDefault(address.ZipCode);
            AssertExtensions.IsDefault(address.City);
            AssertExtensions.IsDefault(address.Country);
        }

        [Test]
        public void SetAddressLine()
        {
            var address = new Address();
            var addressLine = "Test 1, 2, 3.";
            address.AddressLine = addressLine;

            Assert.AreEqual(addressLine, address.AddressLine);
        }

        [Test]
        public void SetZipCode()
        {
            var address = new Address();
            var zipCode = "8001";
            address.ZipCode = zipCode;

            Assert.AreEqual(zipCode, address.ZipCode);
        }

        [Test]
        public void SetCountry()
        {
            var address = new Address();
            var country = "Test 1, 2, 3.";
            address.Country = country;

            Assert.AreEqual(country, address.Country);
        }
    }
}
