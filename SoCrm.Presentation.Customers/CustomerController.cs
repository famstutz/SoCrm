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

    using SoCrm.Presentation.Contacts;
    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.CompanyList;
    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Presentation.Customers.CreateCustomer;
    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Presentation.Customers.CustomerList;
    using SoCrm.Services.Customers.Contracts;

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
        /// The create customer view model
        /// </summary>
        private ICreateCustomerViewModel createCustomerViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="mainRegion">The main region.</param>
        public CustomerController(IUnityContainer container, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
            : base(container, mainRegion)
        {
            this.container = container;
        }

        /// <summary>
        /// Navigates to customers list.
        /// </summary>
        public void NavigateToCustomerList()
        {
            var customerListViewModel = this.container.Resolve<ICustomerListViewModel>();
            this.MainRegion.Context = customerListViewModel;
        }

        /// <summary>
        /// Navigates to new customer.
        /// </summary>
        public void NavigateToCreateCustomer()
        {
            this.createCustomerViewModel = this.container.Resolve<ICreateCustomerViewModel>();
            this.MainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates to create company.
        /// </summary>
        public void NavigateToCreateCompany()
        {
            var createCompanyViewModel = this.container.Resolve<ICreateCompanyViewModel>();
            this.MainRegion.Context = createCompanyViewModel;
        }

        /// <summary>
        /// Navigates to create E mail address.
        /// </summary>
        public void NavigateToCreateEMailAddress()
        {
            var createEMailAddressViewModel = this.container.Resolve<ICreateEMailAddressViewModel>();
            this.MainRegion.Context = createEMailAddressViewModel;
        }

        /// <summary>
        /// Navigates to create phone number.
        /// </summary>
        public void NavigateToCreatePhoneNumber()
        {
            var createPhoneNumberViewModel = this.container.Resolve<ICreatePhoneNumberViewModel>();
            this.MainRegion.Context = createPhoneNumberViewModel;
        }

        /// <summary>
        /// Navigates to company list.
        /// </summary>
        public void NavigateToCompanyList()
        {
            var companyListViewModel = this.container.Resolve<ICompanyListViewModel>();
            this.MainRegion.Context = companyListViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="company">The company.</param>
        public void NavigateBackToCreateCustomer(Company company)
        {
            this.createCustomerViewModel.Companies.Add(company);
            this.createCustomerViewModel.Company = company;
            this.MainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public void NavigateBackToCreateCustomer(EMailAddress emailAddress)
        {
            this.createCustomerViewModel.EMailAddresses.Add(emailAddress);
            this.MainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        public void NavigateBackToCreateCustomer(PhoneNumber phoneNumber)
        {
            this.createCustomerViewModel.PhoneNumbers.Add(phoneNumber);
            this.MainRegion.Context = this.createCustomerViewModel;
        }

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        /// <param name="person">The person.</param>
        public void NavigateToCreateContact(Person person)
        {
            var contactController = this.container.Resolve<IContactController>();
            contactController.NavigateToCreateContact(person);
        }
    }
}
