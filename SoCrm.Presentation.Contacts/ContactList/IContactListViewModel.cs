// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactListViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact list view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts.ContactList
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The contact list view model.
    /// </summary>
    public interface IContactListViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        Person Person { get; set; }
    }
}
