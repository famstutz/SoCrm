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
    }
}
