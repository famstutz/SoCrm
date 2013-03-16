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
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Customers;
    using SoCrm.Presentation.Security;

    /// <summary>
    /// The app controller.
    /// </summary>
    public class AppController : IAppController
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
        /// Initializes a new instance of the <see cref="AppController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AppController(IUnityContainer container)
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
        /// <returns></returns>
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
    }
}
