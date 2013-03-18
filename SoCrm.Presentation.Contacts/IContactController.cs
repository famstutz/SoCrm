// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The contact controller.
    /// </summary>
    public interface IContactController : IController
    {
        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        /// <param name="person">The person.</param>
        void NavigateToCreateContact(Person person);

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        void NavigateToCreateContact();

        /// <summary>
        /// Navigates to contact list.
        /// </summary>
        void NavigateToContactList();
    }
}
