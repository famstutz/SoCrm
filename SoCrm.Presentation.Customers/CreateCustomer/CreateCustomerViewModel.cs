namespace SoCrm.Presentation.Customers.CreateCustomer
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    public class CreateCustomerViewModel : ViewModelBase, ICreateCustomerViewModel
    {
        private readonly ICustomerController customerController;

        private readonly ICustomerService customerService;

        private string firstName;

        private string lastName;

        private string addressLine;

        private string zipCode;

        private string city;

        private ObservableCollection<string> countries;

        private string country;

        private ObservableCollection<Company> companies;

        private Company company;

        private ObservableCollection<EMailAddress> emailAddresses;

        private EMailAddress selectedEMailAddress;

        private ObservableCollection<PhoneNumber> phoneNumbers;

        private PhoneNumber selectedPhoneNumber;

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

        public ICommand CreateCustomerCommand { get; private set; }

        public ICommand CreateCompanyCommand { get; private set; }

        public ICommand CreateEMailAddressCommand { get; private set; }

        public ICommand CreatePhoneNumberCommand { get; private set; }

        public ICommand DeleteEMailAddressCommand { get; private set; }

        public ICommand DeletePhoneNumberCommand { get; private set; }

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
                this.PhoneNumbers.ToArray(),
                this.EMailAddresses.ToArray());
            this.customerController.NavigateToCustomerList();
        }

        private void OnDeleteEMailAddress(object obj)
        {
            var emailAddress = (EMailAddress)obj;
            this.customerService.DeleteEMailAddress(emailAddress);
            this.EMailAddresses.Remove(emailAddress);
        }

        private void OnDeletePhoneNumber(object obj)
        {
            var phoneNumber = (PhoneNumber)obj;
            this.customerService.DeletePhoneNumber(phoneNumber);
            this.PhoneNumbers.Remove(phoneNumber);
        }

    }
}
