// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAppController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The app controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The app controller.
    /// </summary>
    public interface IAppController : IController
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        User CurrentUser { get; set; }

        /// <summary>
        /// Goes to user list.
        /// </summary>
        void NavigateToUserList();

        /// <summary>
        /// Goes to create user.
        /// </summary>
        void NavigateToCreateUser();

        /// <summary>
        /// Navigates to customer list.
        /// </summary>
        void NavigateToCustomerList();

        /// <summary>
        /// Navigates to create customer.
        /// </summary>
        void NavigateToCreateCustomer();

        /// <summary>
        /// Navigates to company list.
        /// </summary>
        void NavigateToCompanyList();
    }
}
