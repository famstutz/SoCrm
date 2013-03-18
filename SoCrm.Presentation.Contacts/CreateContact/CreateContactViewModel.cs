// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateContactViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create contact view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts.CreateContact
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    using IContactService = SoCrm.Presentation.Contacts.Contact.IContactService;
    using ICustomerService = SoCrm.Presentation.Contacts.Customer.ICustomerService;

    /// <summary>
    /// The create contact view model.
    /// </summary>
    public class CreateContactViewModel : ViewModelBase, ICreateContactViewModel
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
        /// The customer service.
        /// </summary>
        private readonly ICustomerService customerService;

        /// <summary>
        /// The authentication service.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// The persons.
        /// </summary>
        private ObservableCollection<Person> persons;

        /// <summary>
        /// The person.
        /// </summary>
        private Person person;

        /// <summary>
        /// The contact mediums.
        /// </summary>
        private ObservableCollection<ContactMedium> contactMediums;

        /// <summary>
        /// The contact medium.
        /// </summary>
        private ContactMedium contactMedium;

        /// <summary>
        /// The content.
        /// </summary>
        private string content;

        /// <summary>
        /// The date time.
        /// </summary>
        private DateTime dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateContactViewModel"/> class.
        /// </summary>
        /// <param name="contactController">The contact controller.</param>
        /// <param name="contactService">The contact service.</param>
        /// <param name="customerService">The customer service.</param>
        /// <param name="authenticationService">The authentication service.</param>
        public CreateContactViewModel(
            IContactController contactController,
            IContactService contactService,
            ICustomerService customerService,
            IAuthenticationService authenticationService)
        {
            this.contactController = contactController;
            this.contactService = contactService;
            this.customerService = customerService;
            this.authenticationService = authenticationService;

            this.Persons = new ObservableCollection<Person>(this.customerService.GetAllPersons());
            this.ContactMediums = new ObservableCollection<ContactMedium>(this.contactService.GetAllContactMediums());
            this.User = this.authenticationService.CurrentUser;
            this.DateTime = DateTime.Now;

            this.CreateContactCommand = new CommandModel(this.OnCreateContact);
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public ObservableCollection<Person> Persons
        {
            get
            {
                return this.persons;
            }

            set
            {
                if (this.persons != value)
                {
                    this.persons = value;
                    this.OnPropertyChanged("Persons");
                }
            }
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
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (this.content != value)
                {
                    this.content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }

            set
            {
                if (this.dateTime != value)
                {
                    this.dateTime = value;
                    this.OnPropertyChanged("DateTime");
                }
            }
        }

        /// <summary>
        /// Gets the create contact command.
        /// </summary>
        /// <value>
        /// The create contact command.
        /// </value>
        public ICommand CreateContactCommand { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; private set; }

        /// <summary>
        /// Called when contact is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreateContact(object obj)
        {
            this.contactService.CreateContact(this.User, this.Person, this.Content, this.ContactMedium, this.DateTime);
            this.contactController.SetLastStatus(string.Format("Successfully created contact for customer {0} {1}.", this.Person.FirstName, this.Person.LastName));
            this.contactController.NavigateToContactList();
        }
    }
}
