namespace SoCrm.Services.Contacts.Contracts.Tests
{
    using System;

    using NUnit.Framework;

    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;
    using SoCrm.Tests.Common;

    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Constructor()
        {
            var contact = new Contact();

            Assert.IsNotNull(contact);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var contact = new Contact();

            AssertExtensions.IsDefault(contact.UserId);
            AssertExtensions.IsDefault(contact.PersonId);
            AssertExtensions.IsDefault(contact.Content);
            AssertExtensions.IsDefault(contact.Medium);
            AssertExtensions.IsDefault(contact.DateTime);
            AssertExtensions.IsDefault(contact.User);
            AssertExtensions.IsDefault(contact.Person);
        }

        [Test]
        public void SetUserId()
        {
            var contact = new Contact();
            var guid = Guid.NewGuid();
            contact.UserId = guid;

            Assert.AreEqual(guid, contact.UserId);
        }

        [Test]
        public void SetPersonId()
        {
            var contact = new Contact();
            var guid = Guid.NewGuid();
            contact.PersonId = guid;

            Assert.AreEqual(guid, contact.PersonId);
        }

        [Test]
        public void SetContent()
        {
            var contact = new Contact();
            var content = "Test 1, 2, 3.";
            contact.Content = content;

            Assert.AreEqual(content, contact.Content);
        }

        [Test]
        public void SetMedium()
        {
            var contact = new Contact();
            var medium = ContactMedium.Mailing;
            contact.Medium = medium;

            Assert.AreEqual(medium, contact.Medium);
        }

        [Test]
        public void SetDateTime()
        {
            var contact = new Contact();
            var dateTime = DateTime.Now;
            contact.DateTime = dateTime;

            Assert.AreEqual(dateTime, contact.DateTime);
        }

        [Test]
        public void SetUser()
        {
            var contact = new Contact();
            var user = new User { UserName = "Test 1, 2, 3." };
            contact.User = user;

            Assert.AreEqual(user, contact.User);
        }

        [Test]
        public void SetPerson()
        {
            var contact = new Contact();
            var person = new Person { FirstName = "Peter", LastName = "Muster" };
            contact.Person = person;

            Assert.AreEqual(person, contact.Person);
        }
    }
}
