// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCustomerViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create customer view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreateCustomer
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    /// <summary>
    /// The create customer view model.
    /// </summary>
    public class CreateCustomerViewModel : ViewModelBase, ICreateCustomerViewModel
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
        /// The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The address line.
        /// </summary>
        private string addressLine;

        /// <summary>
        /// The zip code.
        /// </summary>
        private string zipCode;

        /// <summary>
        /// The city.
        /// </summary>
        private string city;

        /// <summary>
        /// The countries.
        /// </summary>
        private ObservableCollection<string> countries;

        /// <summary>
        /// The country.
        /// </summary>
        private string country;

        /// <summary>
        /// The companies.
        /// </summary>
        private ObservableCollection<Company> companies;

        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The email addresses.
        /// </summary>
        private ObservableCollection<EMailAddress> emailAddresses;

        /// <summary>
        /// The selected E mail address.
        /// </summary>
        private EMailAddress selectedEMailAddress;

        /// <summary>
        /// The phone numbers.
        /// </summary>
        private ObservableCollection<PhoneNumber> phoneNumbers;

        /// <summary>
        /// The selected phone number.
        /// </summary>
        private PhoneNumber selectedPhoneNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CreateCustomerViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreateCustomerCommand = new CommandModel(this.OnCreateCustomer);
            this.CreateCompanyCommand = new CommandModel(obj => this.customerController.NavigateToCreateCompany());
            this.CreateEMailAddressCommand = new CommandModel(obj => this.customerController.NavigateToCreateEMailAddress());
            this.CreatePhoneNumberCommand = new CommandModel(obj => this.customerController.NavigateToCreatePhoneNumber());
            this.DeleteEMailAddressCommand = new CommandModel(this.OnDeleteEMailAddress);
            this.DeletePhoneNumberCommand = new CommandModel(this.OnDeletePhoneNumber);

            this.Countries = new ObservableCollection<string>(this.customerService.GetAllCountries());
            this.Companies = new ObservableCollection<Company>(this.customerService.GetAllCompanies());
            this.EMailAddresses = new ObservableCollection<EMailAddress>();
            this.PhoneNumbers = new ObservableCollection<PhoneNumber>();
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    this.OnPropertyChanged("FirstName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    this.OnPropertyChanged("LastName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        /// <value>
        /// The address line.
        /// </value>
        public string AddressLine
        {
            get
            {
                return this.addressLine;
            }

            set
            {
                if (this.addressLine != value)
                {
                    this.addressLine = value;
                    this.OnPropertyChanged("AddressLine");
                }
            }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }

            set
            {
                if (this.zipCode != value)
                {
                    this.zipCode = value;
                    this.OnPropertyChanged("ZipCode");
                }
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                if (this.city != value)
                {
                    this.city = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public ObservableCollection<string> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                if (this.countries != value)
                {
                    this.countries = value;
                    this.OnPropertyChanged("Countries");
                }
            }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                if (this.country != value)
                {
                    this.country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public ObservableCollection<Company> Companies
        {
            get
            {
                return this.companies;
            }

            set
            {
                if (this.companies != value)
                {
                    this.companies = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public Company Company
        {
            get
            {
                return this.company;
            }

            set
            {
                if (this.company != value)
                {
                    this.company = value;
                    this.OnPropertyChanged("Company");
                }
            }
        }

        /// <summary>
        /// Gets or sets the E mail addresses.
        /// </summary>
        /// <value>
        /// The E mail addresses.
        /// </value>
        public ObservableCollection<EMailAddress> EMailAddresses
        {
            get
            {
                return this.emailAddresses;
            }

            set
            {
                if (this.emailAddresses != value)
                {
                    this.emailAddresses = value;
                    this.OnPropertyChanged("EMailAddresses");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected E mail address.
        /// </summary>
        /// <value>
        /// The selected E mail address.
        /// </value>
        public EMailAddress SelectedEMailAddress
        {
            get
            {
                return this.selectedEMailAddress;
            }

            set
            {
                if (this.selectedEMailAddress != value)
                {
                    this.selectedEMailAddress = value;
                    this.OnPropertyChanged("SelectedEMailAddress");
                }
            }
        }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public ObservableCollection<PhoneNumber> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            set
            {
                if (this.phoneNumbers != value)
                {
                    this.phoneNumbers = value;
                    this.OnPropertyChanged("PhoneNumbers");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected phone number.
        /// </summary>
        /// <value>
        /// The selected phone number.
        /// </value>
        public PhoneNumber SelectedPhoneNumber
        {
            get
            {
                return this.selectedPhoneNumber;
            }

            set
            {
                if (this.selectedPhoneNumber != value)
                {
                    this.selectedPhoneNumber = value;
                    this.OnPropertyChanged("SelectedPhoneNumber");
                }
            }
        }

        /// <summary>
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        public ICommand CreateCustomerCommand { get; private set; }

        /// <summary>
        /// Gets the create company command.
        /// </summary>
        /// <value>
        /// The create company command.
        /// </value>
        public ICommand CreateCompanyCommand { get; private set; }

        /// <summary>
        /// Gets the create E mail address command.
        /// </summary>
        /// <value>
        /// The create E mail address command.
        /// </value>
        public ICommand CreateEMailAddressCommand { get; private set; }

        /// <summary>
        /// Gets the create phone number command.
        /// </summary>
        /// <value>
        /// The create phone number command.
        /// </value>
        public ICommand CreatePhoneNumberCommand { get; private set; }

        /// <summary>
        /// Gets the delete E mail address command.
        /// </summary>
        /// <value>
        /// The delete E mail address command.
        /// </value>
        public ICommand DeleteEMailAddressCommand { get; private set; }

        /// <summary>
        /// Gets the delete phone number command.
        /// </summary>
        /// <value>
        /// The delete phone number command.
        /// </value>
        public ICommand DeletePhoneNumberCommand { get; private set; }

        /// <summary>
        /// Called when customer is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreateCustomer(object obj)
        {
            this.customerService.CreatePerson(
                this.FirstName,
                this.LastName,
                this.Company,
                this.AddressLine,
                this.ZipCode,
                this.City,
                this.Country,
                this.PhoneNumbers.ToList(),
                this.EMailAddresses.ToList());
            this.customerController.SetLastStatus(string.Format("Successfully created customer {0} {1}.", this.FirstName, this.LastName));
            this.customerController.NavigateToCustomerList();
        }

        /// <summary>
        /// Called when e mail address is deleted.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnDeleteEMailAddress(object obj)
        {
            var emailAddress = (EMailAddress)obj;
            this.customerService.DeleteEMailAddress(emailAddress);
            this.EMailAddresses.Remove(emailAddress);
            this.customerController.SetLastStatus(string.Format("Successfully deleted e-mail address {0}.", emailAddress.Address));
        }

        /// <summary>
        /// Called when phone number is deleted.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnDeletePhoneNumber(object obj)
        {
            var phoneNumber = (PhoneNumber)obj;
            this.customerService.DeletePhoneNumber(phoneNumber);
            this.PhoneNumbers.Remove(phoneNumber);
            this.customerController.SetLastStatus(string.Format("Successfully deleted phone number {0}.", phoneNumber.Number));
        }
    }
}
