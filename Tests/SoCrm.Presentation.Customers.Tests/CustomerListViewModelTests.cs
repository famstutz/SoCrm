namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CustomerList;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CustomerListViewModelTests
    {
        private CustomerListViewModel customerListViewModel;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<ICustomerService> customerServiceMock;

        private List<Person> persons;

        [SetUp]
        public void SetUp()
        {
            this.persons = this.GetPersons();
            this.customerControllerMock = new Mock<ICustomerController>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.customerServiceMock.Setup(s => s.GetPersonsByNameAndCompany(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(this.persons);
            this.customerListViewModel = new CustomerListViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.customerListViewModel = null;
            this.customerControllerMock = null;
            this.customerServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.customerListViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.customerListViewModel.SearchCustomersCommand);
            Assert.IsNotNull(this.customerListViewModel.DeleteCustomerCommand);
            Assert.IsNotNull(this.customerListViewModel.CreateContactCommand);
            CollectionAssert.AreEqual(this.persons, this.customerListViewModel.Persons);
        }

        [Test]
        public void SearchName()
        {
            var name = "Hans";

            this.customerListViewModel.SearchName = name;
            var result = this.customerListViewModel.SearchName;

            Assert.AreEqual(name, result);
        }

        [Test]
        public void SearchCompany()
        {
            var company = "Hanswurscht AG";

            this.customerListViewModel.SearchCompany = company;
            var result = this.customerListViewModel.SearchCompany;

            Assert.AreEqual(company, result);
        }

        [Test]
        public void SearchCustomersCommandExecute()
        {
            var name = "Peter";
            var company = "Google";
            this.customerListViewModel.SearchName = name;
            this.customerListViewModel.SearchCompany = company;
            this.customerServiceMock.Setup(s => s.GetPersonsByNameAndCompany(name, company)).Returns(this.persons);

            this.customerListViewModel.SearchCustomersCommand.Execute(null);
            CollectionAssert.AreEqual(this.persons, this.customerListViewModel.Persons);

            this.customerServiceMock.Verify(s => s.GetPersonsByNameAndCompany(name, company));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void DeleteCustomerCommandExecute()
        {
            var person = new Person { ObjectId = Guid.NewGuid(), FirstName = "Hans", LastName = "Ulrich" };
            this.customerServiceMock.Setup(s => s.DeletePerson(person));

            this.customerListViewModel.DeleteCustomerCommand.Execute(person);

            this.customerServiceMock.Verify(s => s.DeletePerson(person));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void CreateContactCommand()
        {
            this.customerListViewModel.CreateContactCommand.Execute(null);

            this.customerControllerMock.Verify(s => s.NavigateToCreateContact(It.IsAny<Person>()));
        }

        [Test]
        public void Persons()
        {
            this.customerListViewModel.Persons = new ObservableCollection<Person>(this.persons);
            var result = this.customerListViewModel.Persons;

            Assert.AreEqual(this.persons, result);
        }

        [Test]
        public void SeletedPerson()
        {
            var person = new Person { ObjectId = Guid.NewGuid(), FirstName = "Hans", LastName = "Ulrich" };

            this.customerListViewModel.SelectedPerson = person;
            var result = this.customerListViewModel.SelectedPerson;

            Assert.AreEqual(person, result);
        }

        private List<Person> GetPersons()
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
    }
}
