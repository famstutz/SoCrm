namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CompanyList;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CompanyListViewModelTests
    {
        private CompanyListViewModel companyListViewModel;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<ICustomerService> customerServiceMock;

        private List<string> countries;

        private List<Company> companies;

        [SetUp]
        public void SetUp()
        {
            this.countries = new List<string> { "Switzerland", "Germany" };
            this.companies = new List<Company> { new Company { ObjectId = Guid.NewGuid(), Name = "Test AG" } };

            this.customerControllerMock = new Mock<ICustomerController>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.customerServiceMock.Setup(c => c.GetAllCountries()).Returns(this.countries);
            this.customerServiceMock.Setup(c => c.GetAllCompanies()).Returns(this.companies);

            this.companyListViewModel = new CompanyListViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.companyListViewModel = null;
            this.customerControllerMock = null;
            this.customerServiceMock = null;
            this.countries = null;
            this.companies = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.companyListViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.companyListViewModel.DeleteCompanyCommand);
            Assert.IsNotNull(this.companyListViewModel.SearchCompaniesCommand);
            CollectionAssert.AreEqual(this.countries, this.companyListViewModel.Countries);
            CollectionAssert.AreEqual(this.companies, this.companyListViewModel.Companies);
        }

        [Test]
        public void Companies()
        {
            this.companyListViewModel.Companies = new ObservableCollection<Company>(this.companies);

            var result = this.companyListViewModel.Companies;

            CollectionAssert.AreEqual(this.companies, result);
        }

        [Test]
        public void Countries()
        {
            this.companyListViewModel.Countries = new ObservableCollection<string>(this.countries);

            var result = this.companyListViewModel.Countries;

            CollectionAssert.AreEqual(this.countries, result);
        }

        [Test]
        public void SearchCountry()
        {
            var country = "Azerbajan";
            this.companyListViewModel.SearchCountry = country;

            var result = this.companyListViewModel.SearchCountry;

            Assert.AreEqual(country, result);
        }

        [Test]
        public void SearchName()
        {
            var name = "Peter";
            this.companyListViewModel.SearchName = name;

            var result = this.companyListViewModel.SearchName;

            Assert.AreEqual(name, result);
        }

        [Test]
        public void SearchCompaniesCommandExecute()
        {
            var name = "Test AG";
            var country = "Hungaria";
            this.companyListViewModel.SearchName = name;
            this.companyListViewModel.SearchCountry = country;
            this.customerServiceMock.Setup(s => s.GetCompaniesByNameAndCountry(name, country)).Returns(this.companies);

            this.companyListViewModel.SearchCompaniesCommand.Execute(null);
            var result = this.companyListViewModel.Companies;

            CollectionAssert.AreEqual(this.companies, result);
            this.customerServiceMock.Verify(s => s.GetCompaniesByNameAndCountry(name, country));
        }

        [Test]
        public void DeleteCompanyCommandExecute()
        {
            var company = this.companies.First();
            this.customerServiceMock.Setup(s => s.DeleteCompany(company));
            this.customerControllerMock.Setup(s => s.SetLastStatus(It.IsAny<string>()));

            this.companyListViewModel.DeleteCompanyCommand.Execute(company);

            this.customerServiceMock.Verify(s => s.DeleteCompany(company));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }
    }
}
