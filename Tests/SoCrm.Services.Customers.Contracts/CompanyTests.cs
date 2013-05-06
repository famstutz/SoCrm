namespace SoCrm.Services.Customers.Contracts
{
    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class CompanyTests
    {
        [Test]
        public void Constructor()
        {
            var company = new Company();

            Assert.IsNotNull(company);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var company = new Company();

            AssertExtensions.IsDefault(company.Name);
            AssertExtensions.IsDefault(company.Address);
            AssertExtensions.IsDefault(company.Website);
        }

        [Test]
        public void SetName()
        {
            var company = new Company();
            var name = "Test 1, 2, 3.";
            company.Name = name;

            Assert.AreEqual(name, company.Name);
        }

        [Test]
        public void SetAddress()
        {
            var company = new Company();
            var address = new Address { AddressLine = "Test 1, 2, 3." };
            company.Address = address;


            Assert.AreEqual(address, company.Address);
        }

        [Test]
        public void SetWebsite()
        {
            var company = new Company();
            var website = "Test 1, 2, 3.";
            company.Website = website;

            Assert.AreEqual(website, company.Website);
        }
    }
}
