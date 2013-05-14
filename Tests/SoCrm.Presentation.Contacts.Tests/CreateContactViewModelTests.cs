namespace SoCrm.Presentation.Contacts.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts.CreateContact;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    using IContactService = SoCrm.Presentation.Contacts.Contact.IContactService;
    using ICustomerService = SoCrm.Presentation.Contacts.Customer.ICustomerService;

    [TestFixture]
    public class CreateContactViewModelTests
    {
        private CreateContactViewModel createContactViewModel;

        private Mock<IContactController> contactControllerMock;

        private Mock<IContactService> contactServiceMock;

        private Mock<ICustomerService> customerServiceMock;

        private Mock<IAuthenticationService> authenticationServiceMock;

        private List<Person> persons;

        private User user;

        private List<ContactMedium> contactMediums;

        [SetUp]
        public void SetUp()
        {
            this.persons = this.CreatePersons();
            this.user = this.CreateUser();
            this.contactMediums = this.CreateContactMediums();

            this.contactControllerMock = new Mock<IContactController>();
            this.contactServiceMock = new Mock<IContactService>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.authenticationServiceMock = new Mock<IAuthenticationService>();

            this.authenticationServiceMock.Setup(a => a.CurrentUser).Returns(this.user);
            this.customerServiceMock.Setup(c => c.GetAllPersons()).Returns(this.persons);
            this.contactServiceMock.Setup(c => c.GetAllContactMediums()).Returns(this.contactMediums);

            this.createContactViewModel = new CreateContactViewModel(
                this.contactControllerMock.Object,
                this.contactServiceMock.Object,
                this.customerServiceMock.Object,
                this.authenticationServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createContactViewModel = null;
            this.contactControllerMock = null;
            this.contactServiceMock = null;
            this.customerServiceMock = null;
            this.authenticationServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createContactViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.createContactViewModel.DateTime);
            Assert.AreEqual(this.user, this.createContactViewModel.User);
            Assert.IsNotNull(this.createContactViewModel.CreateContactCommand);
            CollectionAssert.AreEqual(this.persons, this.createContactViewModel.Persons);
            CollectionAssert.AreEqual(this.contactMediums, this.createContactViewModel.ContactMediums);
        }

        [Test]
        public void Persons()
        {
            this.createContactViewModel.Persons = new ObservableCollection<Person>(this.persons);
            var result = this.createContactViewModel.Persons;

            CollectionAssert.AreEqual(this.persons, result);
        }

        [Test]
        public void Person()
        {
            var person = this.CreatePersons().First();

            this.createContactViewModel.Person = person;
            var result = this.createContactViewModel.Person;

            Assert.AreEqual(person, result);
        }

        [Test]
        public void ContactMediums()
        {
            this.createContactViewModel.ContactMediums = new ObservableCollection<ContactMedium>(this.contactMediums);
            var result = this.createContactViewModel.ContactMediums;

            Assert.AreEqual(this.contactMediums, result);
        }

        [Test]
        public void ContactMedium()
        {
            var contactMedium = Services.Contacts.Contracts.ContactMedium.EMail;

            this.createContactViewModel.ContactMedium = contactMedium;
            var result = this.createContactViewModel.ContactMedium;

            Assert.AreEqual(contactMedium, result);
        }

        [Test]
        public void Content()
        {
            var content = "Test, 1, 2, 3.";

            this.createContactViewModel.Content = content;
            var result = this.createContactViewModel.Content;

            Assert.AreEqual(content, result);
        }

        [Test]
        public void DateTime()
        {
            var dateTime = System.DateTime.Now.AddDays(2);

            this.createContactViewModel.DateTime = dateTime;
            var result = this.createContactViewModel.DateTime;

            Assert.AreEqual(dateTime, result);
        }

        [Test]
        public void CreateContactCommandExecute()
        {
            var content = "Test 1 2 3";
            var contactMedium = Services.Contacts.Contracts.ContactMedium.EMail;
            var dateTime = System.DateTime.Now.AddMinutes(2);
            var person = this.persons.First();
            this.createContactViewModel.Content = content;
            this.createContactViewModel.Person = person;
            this.createContactViewModel.ContactMedium = contactMedium;
            this.createContactViewModel.DateTime = dateTime;
            this.contactServiceMock.Setup(c => c.CreateContact(this.user, person, content, contactMedium, dateTime));

            this.createContactViewModel.CreateContactCommand.Execute(null);

            this.contactServiceMock.Verify(c => c.CreateContact(this.user, person, content, contactMedium, dateTime));
            this.contactControllerMock.Verify(c => c.SetLastStatus(It.IsAny<string>()));
            this.contactControllerMock.Verify(c => c.NavigateToContactList());
        }

        private List<Person> CreatePersons()
        {
            return new List<Person>
                       {
                           new Person
                               {
                                   ObjectId = Guid.Parse("E5C71CA6-D09A-4E0A-BF10-3CCCA13B6CA3"),
                                   Address =
                                       new Address
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "70947E3A-62BD-4410-B3FF-54E7C560EE3A"),
                                               AddressLine = "Bahnhofstrasse 12",
                                               City = "Zürich",
                                               Country = "Switzerland",
                                               ZipCode = "8001"
                                           },
                                   FirstName = "Hans",
                                   LastName = "Wurscht",
                                   Employer =
                                       new Company
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "104B331E-7672-42DB-9E4A-B8C84659CCC0"),
                                               Name = "Wurschwarenfabrik AG"
                                           }
                               },
                           new Person
                               {
                                   ObjectId = Guid.Parse("2D84E08A-6954-4BF8-B638-DB791BD28C8A"),
                                   Address =
                                       new Address
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "095E0E84-5500-4316-B10F-AACBAB164B9B"),
                                               AddressLine = "Dorfplatz 1",
                                               City = "München",
                                               Country = "Germany",
                                               ZipCode = "23532"
                                           },
                                   FirstName = "Peter",
                                   LastName = "Fleischli"
                               }
                       };
        }

        private List<ContactMedium> CreateContactMediums()
        {
            return new List<ContactMedium>
                       {
                           Services.Contacts.Contracts.ContactMedium.EMail,
                           Services.Contacts.Contracts.ContactMedium.Mailing,
                           Services.Contacts.Contracts.ContactMedium.PhoneCall
                       };
        }

        private User CreateUser()
        {
            return new User
                       {
                           ObjectId = Guid.Parse("F3AD00E1-0D86-4A09-AB1A-FB604D06FBB3"),
                           Password = "7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4=", // plain text: "test123"
                           UserName = "Hans",
                           Role = Role.User
                       };
        }
    }
}
