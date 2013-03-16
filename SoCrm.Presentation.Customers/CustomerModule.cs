// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersModule.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customers module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.CreateCompany;
    using SoCrm.Presentation.Customers.CreateCustomer;
    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Presentation.Customers.Customer;
    using SoCrm.Presentation.Customers.CustomerList;

    /// <summary>
    /// The customers module.
    /// </summary>
    public class CustomerModule : IModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ICustomerController, CustomerController>();

            container.RegisterType<ICustomerListViewModel, CustomerListViewModel>();
            container.RegisterType<ICreateCustomerViewModel, CreateCustomerViewModel>();
            container.RegisterType<ICreateCompanyViewModel, CreateCompanyViewModel>();
            container.RegisterType<ICreateEMailAddressViewModel, CreateEMailAddressViewModel>();
            container.RegisterType<ICreatePhoneNumberViewModel, CreatePhoneNumberViewModel>();

            container.RegisterInstance(typeof(ICustomerService), new CustomerServiceClient(), new ContainerControlledLifetimeManager());
        }
    }
}
