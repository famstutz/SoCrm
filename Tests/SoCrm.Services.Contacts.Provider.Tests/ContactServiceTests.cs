namespace SoCrm.Services.Contacts.Provider.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Contacts.Provider.ContactPersistence;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    [TestFixture]
    public class ContactServiceTests
    {
        private Mock<IPersistenceServiceOf_Contact> contactClientMock;

        private ContactService contactService;

        [SetUp]
        public void SetUp()
        {
            this.contactClientMock = new Mock<IPersistenceServiceOf_Contact>();
            this.contactService = new ContactService(contactClientMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.contactService = null;
            this.contactClientMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(contactService);
        }

        [Test]
        public void GetContactsByPerson()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.GetAll()).Returns(new List<Contact> { contact });

            Assert.AreEqual(contact, contactService.GetContactsByPerson(contact.Person).Single());
            contactClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetContactsByCompany()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.GetAll()).Returns(new List<Contact> { contact });

            Assert.AreEqual(contact, contactService.GetContactsByCompany(contact.Person.Employer).Single());
            contactClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetContactsByUser()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.GetAll()).Returns(new List<Contact> { contact });

            Assert.AreEqual(contact, contactService.GetContactsByUser(contact.User).Single());
            contactClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetContactByObjectId()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.Get(contact.ObjectId)).Returns(contact);

            Assert.AreEqual(contact, contactService.GetContactByObjectId(contact.ObjectId));
            contactClientMock.Verify(c => c.Get(contact.ObjectId));
        }

        [Test]
        public void GetContactsByContactMedium()
        {
            var contactList = new List<Contact> { this.GetContact() };
            contactClientMock.Setup(c => c.GetAll()).Returns(contactList);

            CollectionAssert.AreEqual(contactList, contactService.GetContactsByContactMedium(ContactMedium.EMail));
            contactClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetContactsByContactMediumAndPersonName()
        {
            var contactList = new List<Contact> { this.GetContact() };
            contactClientMock.Setup(c => c.GetAll()).Returns(contactList);

            CollectionAssert.AreEqual(
                contactList, contactService.GetContactsByContactMediumAndPersonName(ContactMedium.EMail, "Hans"));
            contactClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetAllContactMediums()
        {
            var contactMediums = Enum.GetValues(typeof(ContactMedium)).Cast<ContactMedium>();

            CollectionAssert.AreEqual(contactMediums, contactService.GetAllContactMediums());
        }

        [Test]
        public void CreateContact()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.Save(It.IsAny<Contact>())).Returns(contact.ObjectId);
            contactClientMock.Setup(c => c.Get(contact.ObjectId)).Returns(contact);

            var result = contactService.CreateContact(
                contact.User, contact.Person, contact.Content, contact.Medium, contact.DateTime);

            Assert.AreEqual(contact.ObjectId, result.ObjectId);
            contactClientMock.Verify(c => c.Save(It.IsAny<Contact>()));
            contactClientMock.Verify(c => c.Get(contact.ObjectId));
        }

        [Test]
        public void DeleteContact()
        {
            var contact = this.GetContact();
            contactClientMock.Setup(c => c.Remove(contact));

            contactService.DeleteContact(contact);
            contactClientMock.Verify(c => c.Remove(contact));
        }

        private Contact GetContact()
        {
            return new Contact
                       {
                           Content = "Test content 1, 2, 3.",
                           DateTime = DateTime.Now,
                           CreationTimeStamp = DateTime.Now,
                           LastUpdateTimeStamp = DateTime.Now,
                           Medium = ContactMedium.EMail,
                           ObjectId = Guid.Parse("602E80E6-1A6E-49F2-9CD7-7631D451A71A"),
                           Person =
                               new Person
                                   {
                                       FirstName = "Hans",
                                       LastName = "Muster",
                                       ObjectId = Guid.Parse("B4EE1ED5-A60B-41F8-8E25-CA8D930BAE9C"),
                                       Employer =
                                           new Company
                                               {
                                                   ObjectId =
                                                       Guid.Parse(
                                                           "1061C501-91BA-452A-B95C-B1240023D9D2"),
                                                   Name = "Hans Wurscht AG"
                                               }
                                   },
                           PersonId = Guid.Parse("B4EE1ED5-A60B-41F8-8E25-CA8D930BAE9C"),
                           User =
                               new User
                                   {
                                       UserName = "Urs",
                                       ObjectId = Guid.Parse("D13457EA-7C82-414B-80C1-03C6D1A5CFED")
                                   },
                           UserId = Guid.Parse("D13457EA-7C82-414B-80C1-03C6D1A5CFED")
                       };
        }
    }
}
