namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CreateCompanyViewModelTests
    {
        private CreateCompanyViewModel createCompanyViewModel;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<ICustomerService> customerServiceMock;

        private List<string> countries;

        [SetUp]
        public void SetUp()
        {
            this.countries = new List<string> { "Switzerland", "Austria" };
            this.customerControllerMock = new Mock<ICustomerController>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.customerServiceMock.Setup(s => s.GetAllCountries()).Returns(this.countries);
            this.createCompanyViewModel = new CreateCompanyViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createCompanyViewModel = null;
            this.customerControllerMock = null;
            this.customerServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createCompanyViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            CollectionAssert.AreEqual(this.countries, this.createCompanyViewModel.Countries);
            Assert.IsNotNull(this.createCompanyViewModel.CreateCompanyCommand);
        }

        [Test]
        public void Name()
        {
            var name = "Florian";

            this.createCompanyViewModel.Name = name;
            var result = this.createCompanyViewModel.Name;

            Assert.AreEqual(name, result);
        }

        [Test]
        public void Website()
        {
            var website = "http://www.test.ch";

            this.createCompanyViewModel.Website = website;
            var result = this.createCompanyViewModel.Website;

            Assert.AreEqual(website, result);
        }

        [Test]
        public void AddressLine()
        {
            var addressLine = "Bahnhofstrasse 82";

            this.createCompanyViewModel.AddressLine = addressLine;
            var result = this.createCompanyViewModel.AddressLine;

            Assert.AreEqual(addressLine, result);
        }

        [Test]
        public void ZipCode()
        {
            var zipCode = "8001";

            this.createCompanyViewModel.ZipCode = zipCode;
            var result = this.createCompanyViewModel.ZipCode;

            Assert.AreEqual(zipCode, result);
        }

        [Test]
        public void City()
        {
            var city = "Zürich";

            this.createCompanyViewModel.City = city;
            var result = this.createCompanyViewModel.City;

            Assert.AreEqual(city, result);
        }

        [Test]
        public void Countries()
        {
            this.createCompanyViewModel.Countries = new ObservableCollection<string>(this.countries);
            var result = this.createCompanyViewModel.Countries;

            Assert.AreEqual(this.countries, result);
        }

        [Test]
        public void Country()
        {
            var country = "China";

            this.createCompanyViewModel.Country = country;
            var result = this.createCompanyViewModel.Country;

            Assert.AreEqual(country, result);
        }

        [Test]
        public void CreateCompanyCommandExecute()
        {
            var name = "Hanswurscht AG";
            var addressLine = "Dorfstrasse 19";
            var zipCode = "6373";
            var city = "Ennetbürgen";
            var country = "Switzerland";
            var website = "http://www.hanswurscht.ch";
            var company = new Company
                              {
                                  ObjectId = Guid.NewGuid(),
                                  Name = name,
                                  Website = website,
                                  Address =
                                      new Address
                                          {
                                              ObjectId = Guid.NewGuid(),
                                              AddressLine = addressLine,
                                              City = city,
                                              Country = country
                                          }
                              };

            this.customerServiceMock.Setup(s => s.CreateCompany(name, addressLine, zipCode, city, country, website)).Returns(company);

            this.createCompanyViewModel.Name = name;
            this.createCompanyViewModel.AddressLine = addressLine;
            this.createCompanyViewModel.ZipCode = zipCode;
            this.createCompanyViewModel.City = city;
            this.createCompanyViewModel.Country = country;
            this.createCompanyViewModel.Website = website;

            this.createCompanyViewModel.CreateCompanyCommand.Execute(null);
            
            this.customerServiceMock.Verify(s => s.CreateCompany(name, addressLine, zipCode, city, country, website));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.customerControllerMock.Verify(s => s.NavigateBackToCreateCustomer(company));
        }
    }
}
