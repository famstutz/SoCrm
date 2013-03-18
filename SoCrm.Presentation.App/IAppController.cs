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

    /// <summary>
    /// The app controller.
    /// </summary>
    public interface IAppController : IController
    {
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

        /// <summary>
        /// Navigates to authentication.
        /// </summary>
        void NavigateToAuthentication();

        /// <summary>
        /// Navigates to contact list.
        /// </summary>
        void NavigateToContactList();

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        void NavigateToCreateContact();
    }
}
