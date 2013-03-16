// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customers controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The customers controller.
    /// </summary>
    public interface ICustomerController : IController
    {
        /// <summary>
        /// Navigates to customers list.
        /// </summary>
        void NavigateToCustomerList();

        /// <summary>
        /// Navigates to new customer.
        /// </summary>
        void NavigateToCreateCustomer();

        /// <summary>
        /// Navigates to create company.
        /// </summary>
        void NavigateToCreateCompany();

        /// <summary>
        /// Navigates to create E mail address.
        /// </summary>
        void NavigateToCreateEMailAddress();

        /// <summary>
        /// Navigates to create phone number.
        /// </summary>
        void NavigateToCreatePhoneNumber();

        /// <summary>
        /// Navigates to company list.
        /// </summary>
        void NavigateToCompanyList();

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="company">The company.</param>
        void NavigateBackToCreateCustomer(Company company);

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        void NavigateBackToCreateCustomer(EMailAddress emailAddress);

        /// <summary>
        /// Navigates the back to create customer.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        void NavigateBackToCreateCustomer(PhoneNumber phoneNumber);
    }
}
