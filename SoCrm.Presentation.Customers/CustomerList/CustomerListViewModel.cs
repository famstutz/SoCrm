// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerListViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer list view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CustomerList
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    /// <summary>
    /// The customer list view model.
    /// </summary>
    public class CustomerListViewModel : ViewModelBase, ICustomerListViewModel
    {
        /// <summary>
        /// The customer controller.
        /// </summary>
        private readonly ICustomerController customerController;

        /// <summary>
        /// The customer service.
        /// </summary>
        private readonly ICustomerService customerService;

        /// <summary>
        /// The search name.
        /// </summary>
        private string searchName;

        /// <summary>
        /// The search company.
        /// </summary>
        private string searchCompany;

        /// <summary>
        /// The persons.
        /// </summary>
        private ObservableCollection<Person> persons;

        /// <summary>
        /// The selected person.
        /// </summary>
        private Person selectedPerson;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerListViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CustomerListViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.SearchCustomersCommand = new CommandModel(this.OnSearchCustomers);
            this.DeleteCustomerCommand = new CommandModel(this.OnDeleteCustomer);
            this.CreateContactCommand = new CommandModel(obj => this.customerController.NavigateToCreateContact(this.SelectedPerson));

            this.Persons = new ObservableCollection<Person>(this.customerService.GetPersonsByNameAndCompany(this.SearchName, this.SearchCompany));
        }

        /// <summary>
        /// Gets or sets the name of the search.
        /// </summary>
        /// <value>
        /// The name of the search.
        /// </value>
        public string SearchName
        {
            get
            {
                return this.searchName;
            }

            set
            {
                if (this.searchName != value)
                {
                    this.searchName = value;
                    this.OnPropertyChanged("SearchName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the search company.
        /// </summary>
        /// <value>
        /// The search company.
        /// </value>
        public string SearchCompany
        {
            get
            {
                return this.searchCompany;
            }

            set
            {
                if (this.searchCompany != value)
                {
                    this.searchCompany = value;
                    this.OnPropertyChanged("SearchCompany");
                }
            }
        }

        /// <summary>
        /// Gets the search customers command.
        /// </summary>
        /// <value>
        /// The search customers command.
        /// </value>
        public ICommand SearchCustomersCommand { get; private set; }

        /// <summary>
        /// Gets the delete user command.
        /// </summary>
        /// <value>
        /// The delete user command.
        /// </value>
        public ICommand DeleteCustomerCommand { get; private set; }

        /// <summary>
        /// Gets the create contact command.
        /// </summary>
        /// <value>
        /// The create contact command.
        /// </value>
        public ICommand CreateContactCommand { get; private set; }

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
        /// Gets or sets the selected person.
        /// </summary>
        /// <value>
        /// The selected person.
        /// </value>
        public Person SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }

            set
            {
                if (this.selectedPerson != value)
                {
                    this.selectedPerson = value;
                    this.OnPropertyChanged("SelectedPerson");
                }
            }
        }

        /// <summary>
        /// Called when user is deleted.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnDeleteCustomer(object obj)
        {
            var person = obj as Person;
            this.customerService.DeletePerson(person);
            this.Persons.Remove(person);
            this.customerController.SetLastStatus(string.Format("Successfully deleted {0} {1}.", person.FirstName, person.LastName));
        }

        /// <summary>
        /// Called when customers are searched.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSearchCustomers(object obj)
        {
            this.Persons = new ObservableCollection<Person>(this.customerService.GetPersonsByNameAndCompany(this.SearchName, this.SearchCompany));
            this.customerController.SetLastStatus(string.Format("Found {0} customers.", this.Persons.Count));
        }
    }
}
