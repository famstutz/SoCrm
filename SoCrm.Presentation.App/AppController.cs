// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The app controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App
{
    using System;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Contacts;
    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers;
    using SoCrm.Presentation.Security;

    /// <summary>
    /// The app controller.
    /// </summary>
    public class AppController : ControllerBase, IAppController
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// The security session container.
        /// </summary>
        private IUnityContainer securitySessionContainer;

        /// <summary>
        /// The customers session container
        /// </summary>
        private IUnityContainer customersSessionContainer;

        /// <summary>
        /// The contact session container.
        /// </summary>
        private IUnityContainer contactSessionContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AppController(IUnityContainer container)
            : base(container, null)
        {
            this.container = container;
        }

        /// <summary>
        /// Goes to user list.
        /// </summary>
        public void NavigateToUserList()
        {
            this.securitySessionContainer = this.GetSecuritySessionContainer();
            var securityController = this.securitySessionContainer.Resolve<ISecurityController>();
            securityController.NavigateToUserList();
        }

        /// <summary>
        /// Goes to create user.
        /// </summary>
        public void NavigateToCreateUser()
        {
            this.securitySessionContainer = this.GetSecuritySessionContainer();
            var securityController = this.securitySessionContainer.Resolve<ISecurityController>();
            securityController.NavigateToCreateUser();
        }

        /// <summary>
        /// Navigates to customer list.
        /// </summary>
        public void NavigateToCustomerList()
        {
            this.customersSessionContainer = this.GetCustomersSessionContainer();
            var customerController = this.customersSessionContainer.Resolve<ICustomerController>();
            customerController.NavigateToCustomerList();
        }

        /// <summary>
        /// Navigates to create customer.
        /// </summary>
        public void NavigateToCreateCustomer()
        {
            this.customersSessionContainer = this.GetCustomersSessionContainer();
            var customerController = this.customersSessionContainer.Resolve<ICustomerController>();
            customerController.NavigateToCreateCustomer();
        }

        /// <summary>
        /// Navigates to company list.
        /// </summary>
        public void NavigateToCompanyList()
        {
            this.customersSessionContainer = this.GetCustomersSessionContainer();
            var customerController = this.customersSessionContainer.Resolve<ICustomerController>();
            customerController.NavigateToCompanyList();
        }

        /// <summary>
        /// Navigates to authentication.
        /// </summary>
        public void NavigateToAuthentication()
        {
            this.securitySessionContainer = this.GetSecuritySessionContainer();
            var securityController = this.securitySessionContainer.Resolve<ISecurityController>();
            securityController.NavigateToAuthentication();
        }

        /// <summary>
        /// Navigates to contact list.
        /// </summary>
        public void NavigateToContactList()
        {
            this.contactSessionContainer = this.GetContactsSessionContainer();
            var contactController = this.contactSessionContainer.Resolve<IContactController>();
            contactController.NavigateToContactList();
        }

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        public void NavigateToCreateContact()
        {
            this.contactSessionContainer = this.GetContactsSessionContainer();
            var contactController = this.contactSessionContainer.Resolve<IContactController>();
            contactController.NavigateToCreateContact();
        }

        /// <summary>
        /// Gets the security session container.
        /// </summary>
        /// <param name="create">if set to <c>true</c> [create].</param>
        /// <returns>A container.</returns>
        private IUnityContainer GetSecuritySessionContainer(bool create = false)
        {
            if (create || this.securitySessionContainer == null)
            {
                this.securitySessionContainer = this.container.CreateChildContainer();
                var securityController = this.securitySessionContainer.Resolve<ISecurityController>();
                this.securitySessionContainer.RegisterInstance(
                    securityController, new ContainerControlledLifetimeManager());
            }

            return this.securitySessionContainer;
        }

        /// <summary>
        /// Gets the customers session container.
        /// </summary>
        /// <param name="create">if set to <c>true</c> [create].</param>
        /// <returns>The session container.</returns>
        private IUnityContainer GetCustomersSessionContainer(bool create = false)
        {
            if (create || this.customersSessionContainer == null)
            {
                this.customersSessionContainer = this.container.CreateChildContainer();
                var customerController = this.customersSessionContainer.Resolve<ICustomerController>();
                this.customersSessionContainer.RegisterInstance(
                    customerController, new ContainerControlledLifetimeManager());
            }

            return this.customersSessionContainer;
        }

        /// <summary>
        /// Gets the contacts session container.
        /// </summary>
        /// <param name="create">if set to <c>true</c> [create].</param>
        /// <returns>The session container.</returns>
        private IUnityContainer GetContactsSessionContainer(bool create = false)
        {
            if (create || this.contactSessionContainer == null)
            {
                this.contactSessionContainer = this.container.CreateChildContainer();
                var contactController = this.contactSessionContainer.Resolve<IContactController>();
                this.contactSessionContainer.RegisterInstance(
                    contactController, new ContainerControlledLifetimeManager());
            }

            return this.contactSessionContainer;
        }
    }
}
