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
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Contacts.Contracts;

    using IContactService = SoCrm.Presentation.Contacts.Contact.IContactService;

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
        private string searchPersonName;

        /// <summary>
        /// The contact mediums.
        /// </summary>
        private ObservableCollection<ContactMedium> contactMediums;

        /// <summary>
        /// The contact medium.
        /// </summary>
        private ContactMedium contactMedium;

        /// <summary>
        /// The contacts.
        /// </summary>
        private ObservableCollection<Contact> contacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListViewModel"/> class.
        /// </summary>
        /// <param name="contactController">The contact controller.</param>
        /// <param name="contactService">The contact service.</param>
        public ContactListViewModel(IContactController contactController, IContactService contactService)
        {
            this.contactController = contactController;
            this.contactService = contactService;

            this.ContactMediums = new ObservableCollection<ContactMedium>(this.contactService.GetAllContactMediums());
            this.Contacts = new ObservableCollection<Contact>(this.contactService.GetContactsByContactMedium(this.ContactMedium));

            this.SearchContactsCommand = new CommandModel(this.OnSearchContacts);
            this.DeleteContactCommand = new CommandModel(this.OnDeleteContact);
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public string SearchPersonName
        {
            get
            {
                return this.searchPersonName;
            }

            set
            {
                if (this.searchPersonName != value)
                {
                    this.searchPersonName = value;
                    this.OnPropertyChanged("SearchPersonName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the contact mediums.
        /// </summary>
        /// <value>
        /// The contact mediums.
        /// </value>
        public ObservableCollection<ContactMedium> ContactMediums
        {
            get
            {
                return this.contactMediums;
            }

            set
            {
                if (this.contactMediums != value)
                {
                    this.contactMediums = value;
                    this.OnPropertyChanged("ContactMediums");
                }
            }
        }

        /// <summary>
        /// Gets or sets the contact medium.
        /// </summary>
        /// <value>
        /// The contact medium.
        /// </value>
        public ContactMedium ContactMedium
        {
            get
            {
                return this.contactMedium;
            }

            set
            {
                if (this.contactMedium != value)
                {
                    this.contactMedium = value;
                    this.OnPropertyChanged("ContactMedium");
                }
            }
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return this.contacts;
            }

            set
            {
                if (this.contacts != value)
                {
                    this.contacts = value;
                    this.OnPropertyChanged("Contacts");
                }
            }
        }

        /// <summary>
        /// Gets the search contacts command.
        /// </summary>
        /// <value>
        /// The search contacts command.
        /// </value>
        public ICommand SearchContactsCommand { get; private set; }

        /// <summary>
        /// Gets the delete contact command.
        /// </summary>
        /// <value>
        /// The delete contact command.
        /// </value>
        public ICommand DeleteContactCommand { get; private set; }

        /// <summary>
        /// Called when [delete contact].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnDeleteContact(object obj)
        {
            var contact = obj as Contact;
            this.contactService.DeleteContact(contact);
            this.Contacts.Remove(contact);
            this.contactController.SetLastStatus(string.Format("Successfully deleted contact for {0} {1}.", contact.Person.FirstName, contact.Person.LastName));
        }

        /// <summary>
        /// Called when contacts are searched.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSearchContacts(object obj)
        {
            this.Contacts = new ObservableCollection<Contact>(this.contactService.GetContactsByContactMediumAndPersonName(this.ContactMedium, this.SearchPersonName));
            this.contactController.SetLastStatus(string.Format("Found {0} contacts.", this.Contacts.Count));
        }
    }
}
