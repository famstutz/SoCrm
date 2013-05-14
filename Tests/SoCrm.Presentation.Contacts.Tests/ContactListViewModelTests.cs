namespace SoCrm.Presentation.Contacts.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts.ContactList;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    using IContactService = SoCrm.Presentation.Contacts.Contact.IContactService;

    [TestFixture]
    public class ContactListViewModelTests
    {
        private ContactListViewModel contactListViewModel;

        private Mock<IContactController> contactControllerMock;

        private Mock<IContactService> contactServiceMock;

        private List<ContactMedium> contactMediums;

        private List<Contact> contacts;

        [SetUp]
        public void SetUp()
        {
            this.contactMediums = this.CreateContactMediums();
            this.contacts = this.CreateContacts();
            this.contactControllerMock = new Mock<IContactController>();
            this.contactServiceMock = new Mock<IContactService>();
            this.contactServiceMock.Setup(s => s.GetAllContactMediums()).Returns(this.contactMediums);
            this.contactServiceMock.Setup(s => s.GetContactsByContactMedium(It.IsAny<ContactMedium>())).Returns(this.contacts);
            this.contactListViewModel = new ContactListViewModel(
                this.contactControllerMock.Object, this.contactServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.contactListViewModel = null;
            this.contactControllerMock = null;
            this.contactServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.contactListViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.contactListViewModel.SearchContactsCommand);
            Assert.IsNotNull(this.contactListViewModel.DeleteContactCommand);
            CollectionAssert.AreEqual(this.contactMediums, this.contactListViewModel.ContactMediums);
            CollectionAssert.AreEqual(this.contacts, this.contactListViewModel.Contacts);
        }

        [Test]
        public void SearchPersonName()
        {
            var name = "Peter";

            this.contactListViewModel.SearchPersonName = name;
            var result = this.contactListViewModel.SearchPersonName;

            Assert.AreEqual(name, result);
        }

        [Test]
        public void ContactMediums()
        {
            this.contactListViewModel.ContactMediums = new ObservableCollection<ContactMedium>(this.contactMediums);
            var result = this.contactListViewModel.ContactMediums;

            CollectionAssert.AreEqual(this.contactMediums, result);
        }

        [Test]
        public void ContactMedium()
        {
            var contactMedium = Services.Contacts.Contracts.ContactMedium.PhoneCall;

            this.contactListViewModel.ContactMedium = contactMedium;
            var result = this.contactListViewModel.ContactMedium;

            Assert.AreEqual(contactMedium, result);
        }

        [Test]
        public void Contacts()
        {
            this.contactListViewModel.Contacts = new ObservableCollection<Contact>(this.contacts);
            var result = this.contactListViewModel.Contacts;

            CollectionAssert.AreEqual(this.contacts, result);
        }

        [Test]
        public void SearchContactsCommandExecute()
        {
            var name = "Peter";
            var contactMedium = Services.Contacts.Contracts.ContactMedium.PhoneCall;
            this.contactListViewModel.SearchPersonName = name;
            this.contactListViewModel.ContactMedium = contactMedium;
            this.contactServiceMock.Setup(c => c.GetContactsByContactMediumAndPersonName(contactMedium, name))
                .Returns(this.contacts);

            this.contactListViewModel.SearchContactsCommand.Execute(null);

            CollectionAssert.AreEqual(this.contacts, this.contactListViewModel.Contacts);
            this.contactServiceMock.Verify(c => c.GetContactsByContactMediumAndPersonName(contactMedium, name));
            this.contactControllerMock.Verify(c => c.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void DeleteContactsCommandExecute()
        {
            var contact = this.CreateContacts().First();
            this.contactServiceMock.Setup(c => c.DeleteContact(contact));

            this.contactListViewModel.DeleteContactCommand.Execute(contact);

            this.contactServiceMock.Verify(c => c.DeleteContact(contact));
            this.contactControllerMock.Verify(c => c.SetLastStatus(It.IsAny<string>()));
        }

        private List<ContactMedium> CreateContactMediums()
        {
            return new List<ContactMedium>
                       {
                           Services.Contacts.Contracts.ContactMedium.EMail,
                           Services.Contacts.Contracts.ContactMedium.Fair,
                           Services.Contacts.Contracts.ContactMedium.Mailing
                       };
        }

        private List<Contact> CreateContacts()
        {
            return new List<Contact>
                       {
                           new Contact
                               {
                                   Content = "Test content 1, 2, 3.",
                                   DateTime = DateTime.Now,
                                   CreationTimeStamp = DateTime.Now,
                                   LastUpdateTimeStamp = DateTime.Now,
                                   Medium = Services.Contacts.Contracts.ContactMedium.EMail,
                                   ObjectId = Guid.Parse("602E80E6-1A6E-49F2-9CD7-7631D451A71A"),
                                   Person =
                                       new Person
                                           {
                                               FirstName = "Hans",
                                               LastName = "Muster",
                                               ObjectId =
                                                   Guid.Parse(
                                                       "B4EE1ED5-A60B-41F8-8E25-CA8D930BAE9C"),
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
                                               ObjectId =
                                                   Guid.Parse(
                                                       "D13457EA-7C82-414B-80C1-03C6D1A5CFED")
                                           },
                                   UserId = Guid.Parse("D13457EA-7C82-414B-80C1-03C6D1A5CFED")
                               }
                       };
        }
    }
}
