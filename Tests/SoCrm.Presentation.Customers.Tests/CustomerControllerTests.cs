namespace SoCrm.Presentation.Customers.Tests
{
    using System.Collections.ObjectModel;

    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Customers.CompanyList;
    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Presentation.Customers.CreateCustomer;
    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Presentation.Customers.CustomerList;
    using SoCrm.Services.Customers.Contracts;

    [TestFixture]
    public class CustomerControllerTests
    {
        private IUnityContainer unityContainer;

        private Mock<IStatusBarService> statusBarServiceMock;

        private Mock<IRegion> regionMock;

        private Mock<ICustomerListViewModel> customerListViewModelMock;

        private Mock<ICreateCustomerViewModel> createCustomerViewModelMock;

        private Mock<ICreateCompanyViewModel> createCompanyViewModelMock;

        private Mock<ICreateEMailAddressViewModel> createEMailAddressViewModelMock;

        private Mock<ICreatePhoneNumberViewModel> createPhoneNumberViewModelMock;

        private Mock<ICompanyListViewModel> companyListViewModelMock;

        private Mock<IContactController> contactControllerMock;

        [SetUp]
        public void SetUp()
        {
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.regionMock = new Mock<IRegion>();
            this.customerListViewModelMock = new Mock<ICustomerListViewModel>();
            this.createCustomerViewModelMock = new Mock<ICreateCustomerViewModel>();
            this.createCompanyViewModelMock = new Mock<ICreateCompanyViewModel>();
            this.createEMailAddressViewModelMock = new Mock<ICreateEMailAddressViewModel>();
            this.createPhoneNumberViewModelMock = new Mock<ICreatePhoneNumberViewModel>();
            this.companyListViewModelMock = new Mock<ICompanyListViewModel>();
            this.contactControllerMock = new Mock<IContactController>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
            this.unityContainer.RegisterInstance(this.customerListViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.createCustomerViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.createCompanyViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.createEMailAddressViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.createPhoneNumberViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.companyListViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.contactControllerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.regionMock = null;
            this.customerListViewModelMock = null;
            this.createCompanyViewModelMock = null;
            this.createEMailAddressViewModelMock = null;
            this.createPhoneNumberViewModelMock = null;
            this.companyListViewModelMock = null;
            this.statusBarServiceMock = null;
            this.contactControllerMock = null;
        }

        [Test]
        public void Constructor()
        {
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            Assert.IsNotNull(customerController);
        }

        [Test]
        public void NavigateToCustomerList()
        {
            this.regionMock.SetupSet(r => r.Context = this.customerListViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCustomerList();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateCustomer()
        {
            this.regionMock.SetupSet(r => r.Context = this.createCustomerViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCreateCustomer();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateCompany()
        {
            this.regionMock.SetupSet(r => r.Context = this.createCompanyViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCreateCompany();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateEMailAddress()
        {
            this.regionMock.SetupSet(r => r.Context = this.createEMailAddressViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCreateEMailAddress();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreatePhoneNumber()
        {
            this.regionMock.SetupSet(r => r.Context = this.createPhoneNumberViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCreatePhoneNumber();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCompanyList()
        {
            this.regionMock.SetupSet(r => r.Context = this.companyListViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCompanyList();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateBackToCreateCustomer_Company()
        {
            var company = new Company();
            this.regionMock.SetupSet(r => r.Context = this.createCustomerViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);
            this.createCustomerViewModelMock.Setup(c => c.Companies).Returns(new ObservableCollection<Company>());
            customerController.NavigateToCreateCustomer();

            customerController.NavigateBackToCreateCustomer(company);

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateBackToCreateCustomer_EMailAddress()
        {
            var emailAddress = new EMailAddress();
            this.regionMock.SetupSet(r => r.Context = this.createCustomerViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);
            this.createCustomerViewModelMock.Setup(c => c.EMailAddresses).Returns(new ObservableCollection<EMailAddress>());
            customerController.NavigateToCreateCustomer();

            customerController.NavigateBackToCreateCustomer(emailAddress);

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateBackToCreateCustomer_PhoneNumber()
        {
            var phoneNumber = new PhoneNumber();
            this.regionMock.SetupSet(r => r.Context = this.createCustomerViewModelMock.Object).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);
            this.createCustomerViewModelMock.Setup(c => c.PhoneNumbers).Returns(new ObservableCollection<PhoneNumber>());
            customerController.NavigateToCreateCustomer();

            customerController.NavigateBackToCreateCustomer(phoneNumber);

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateContact()
        {
            var person = new Person();
            this.contactControllerMock.Setup(c => c.NavigateToCreateContact(It.IsAny<Person>())).Verifiable();
            var customerController = new CustomerController(this.unityContainer, this.regionMock.Object);

            customerController.NavigateToCreateContact(person);

            this.contactControllerMock.Verify();
        }
    }
}
