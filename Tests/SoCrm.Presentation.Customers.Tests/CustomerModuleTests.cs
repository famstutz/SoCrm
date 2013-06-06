namespace SoCrm.Presentation.Customers.Tests
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers;
    using SoCrm.Presentation.Customers.CompanyList;
    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Presentation.Customers.Customer;
    using SoCrm.Presentation.Customers.CreateCustomer;

    [TestFixture]
    public class CustomerModuleTests
    {
        [Test]
        public void Constructor()
        {
            var customerModule = new CustomerModule();

            Assert.IsNotNull(customerModule);
        }

        [Test]
        public void Register()
        {
            var unityContainer = new UnityContainer();
            var customerModule = new CustomerModule();

            customerModule.Register(unityContainer);

            Assert.IsTrue(unityContainer.IsRegistered<ICustomerController>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreateCustomerViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreateCompanyViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreateEMailAddressViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreatePhoneNumberViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICompanyListViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICustomerService>());
        }
    }
}
