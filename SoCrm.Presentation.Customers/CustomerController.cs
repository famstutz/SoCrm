// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.CompanyList;
    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Presentation.Customers.CreateCustomer;
    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Presentation.Customers.Customer;
    using SoCrm.Presentation.Customers.CustomerList;

    /// <summary>
    /// The customer controller.
    /// </summary>
    public class CustomerController : ControllerBase, ICustomerController
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// The main region.
        /// </summary>
        private readonly IRegion mainRegion;

        /// <summary>
        /// The create customer view model
        /// </summary>
        private ICreateCustomerViewModel createCustomerViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="mainRegion">The main region.</param>
        public CustomerController(IUnityContainer container, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
            : base(container)
        {
            this.container = container;
            this.mainRegion = mainRegion;
        }

        /// <summary>
        /// Navigates to customers list.
        /// </summary>
        public void NavigateToCustomerList()
        {
            var customerListViewModel = this.container.Resolve<ICustomerListViewModel>();
            this.mainRegion.Context = customerListViewModel;
        }

        /// <summary>
        /// Navigates to new customer.
        /// </summary>
        public void NavigateToCreateCustomer()
        {
            this.createCustomerViewModel = this.container.Resolve<ICreateCustomerViewModel>();
            this.mainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates to create company.
        /// </summary>
        public void NavigateToCreateCompany()
        {
            var createCompanyViewModel = this.container.Resolve<ICreateCompanyViewModel>();
            this.mainRegion.Context = createCompanyViewModel;
        }

        /// <summary>
        /// Navigates to create E mail address.
        /// </summary>
        public void NavigateToCreateEMailAddress()
        {
            var createEMailAddressViewModel = this.container.Resolve<ICreateEMailAddressViewModel>();
            this.mainRegion.Context = createEMailAddressViewModel;
        }

        /// <summary>
        /// Navigates to create phone number.
        /// </summary>
        public void NavigateToCreatePhoneNumber()
        {
            var createPhoneNumberViewModel = this.container.Resolve<ICreatePhoneNumberViewModel>();
            this.mainRegion.Context = createPhoneNumberViewModel;
        }

        /// <summary>
        /// Navigates to company list.
        /// </summary>
        public void NavigateToCompanyList()
        {
            var companyListViewModel = this.container.Resolve<ICompanyListViewModel>();
            this.mainRegion.Context = companyListViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="company">The company.</param>
        public void NavigateBackToCreateCustomer(Company company)
        {
            this.createCustomerViewModel.Companies.Add(company);
            this.createCustomerViewModel.Company = company;
            this.mainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public void NavigateBackToCreateCustomer(EMailAddress emailAddress)
        {
            this.createCustomerViewModel.EMailAddresses.Add(emailAddress);
            this.mainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        public void NavigateBackToCreateCustomer(PhoneNumber phoneNumber)
        {
            this.createCustomerViewModel.PhoneNumbers.Add(phoneNumber);
            this.mainRegion.Context = this.createCustomerViewModel;
        }
    }
}
