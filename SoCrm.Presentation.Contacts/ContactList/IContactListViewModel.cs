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
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The contact list view model.
    /// </summary>
    public interface IContactListViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>
        /// The name of the person.
        /// </value>
        string SearchPersonName { get; set; }

        /// <summary>
        /// Gets or sets the contact mediums.
        /// </summary>
        /// <value>
        /// The contact mediums.
        /// </value>
        ObservableCollection<ContactMedium> ContactMediums { get; set; }

        /// <summary>
        /// Gets or sets the contact medium.
        /// </summary>
        /// <value>
        /// The contact medium.
        /// </value>
        ContactMedium ContactMedium { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        ObservableCollection<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets the search contacts command.
        /// </summary>
        /// <value>
        /// The search contacts command.
        /// </value>
        ICommand SearchContactsCommand { get; }

        /// <summary>
        /// Gets the delete contact command.
        /// </summary>
        /// <value>
        /// The delete contact command.
        /// </value>
        ICommand DeleteContactCommand { get; }
    }
}
