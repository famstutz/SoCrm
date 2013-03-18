// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactListViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact list view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts.ContactList
{
    using SoCrm.Presentation.Contacts.Contact;
    using SoCrm.Presentation.Core;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The contact list view model.
    /// </summary>
    public class ContactListViewModel : ViewModelBase, IContactListViewModel
    {
        /// <summary>
        /// The contact controller.
        /// </summary>
        private readonly IContactController contactController;

        /// <summary>
        /// The contact service.
        /// </summary>
        private readonly IContactService contactService;

        /// <summary>
        /// The person.
        /// </summary>
        private Person person;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListViewModel"/> class.
        /// </summary>
        /// <param name="contactController">The contact controller.</param>
        /// <param name="contactService">The contact service.</param>
        public ContactListViewModel(IContactController contactController, IContactService contactService)
        {
            this.contactController = contactController;
            this.contactService = contactService;
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person
        {
            get
            {
                return this.person;
            }

            set
            {
                if (this.person != value)
                {
                    this.person = value;
                    this.OnPropertyChanged("Person");
                }
            }
        }
    }
}
