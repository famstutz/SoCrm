namespace SoCrm.Services.Customers.Contracts.Tests
{
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Constructor()
        {
            var person = new Person();

            Assert.IsNotNull(person);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var person = new Person();

            AssertExtensions.IsDefault(person.FirstName);
            AssertExtensions.IsDefault(person.LastName);
            AssertExtensions.IsDefault(person.Employer);
            AssertExtensions.IsDefault(person.Address);
            AssertExtensions.IsDefault(person.PhoneNumbers);
            AssertExtensions.IsDefault(person.EMailAddresses);
        }

        [Test]
        public void SetFirstName()
        {
            var person = new Person();
            var firstName = "Hans";
            person.FirstName = firstName;

            Assert.AreEqual(firstName, person.FirstName);
        }

        [Test]
        public void SetLastName()
        {
            var person = new Person();
            var lastName = "Muster";
            person.LastName = lastName;

            Assert.AreEqual(lastName, person.LastName);
        }

        [Test]
        public void SetEmployer()
        {
            var person = new Person();
            var company = new Company { Name = "Test AG" };
            person.Employer = company;

            Assert.AreEqual(company, person.Employer);
        }

        [Test]
        public void SetAddress()
        {
            var person = new Person();
            var address = new Address { AddressLine = "Test 1, 2, 3." };
            person.Address = address;

            Assert.AreEqual(address, person.Address);
        }

        [Test]
        public void SetPhoneNumbers()
        {
            var person = new Person();
            var phoneNumbers = new Collection<PhoneNumber> { new PhoneNumber { Number = "079 238 13 23" } };
            person.PhoneNumbers = phoneNumbers;
            
            CollectionAssert.AreEqual(phoneNumbers, person.PhoneNumbers);
        }

        [Test]
        public void SetEMailAddresses()
        {
            var person = new Person();
            var emailAddresses = new Collection<EMailAddress> { new EMailAddress() { Address = "hans@muster.ch" } };
            person.EMailAddresses = emailAddresses;
            
            CollectionAssert.AreEqual(emailAddresses, person.EMailAddresses);
        }
    }
}
