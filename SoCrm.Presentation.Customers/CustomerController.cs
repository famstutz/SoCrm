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
    using System;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.CustomerList;

    /// <summary>
    /// The customer controller.
    /// </summary>
    public class CustomerController : ICustomerController
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
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="mainRegion">The main region.</param>
        public CustomerController(IUnityContainer container, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
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
            throw new NotImplementedException();
        }
    }
}
