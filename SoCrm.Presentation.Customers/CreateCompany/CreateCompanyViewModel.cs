namespace SoCrm.Presentation.Customers.CreateCompany
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    public class CreateCompanyViewModel : ViewModelBase, ICreateCompanyViewModel
    {
        private readonly ICustomerController customerController;

        private readonly ICustomerService customerService;

        private string name;

        private string website;

        private string addressLine;

        private string zipCode;

        private string city;

        private ObservableCollection<string> countries;

        private string country;

        public CreateCompanyViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreateCompanyCommand = new CommandModel(this.OnCreateCompany);

            this.Countries = new ObservableCollection<string>(this.customerService.GetAllCountries());
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string Website
        {
            get
            {
                return this.website;
            }

            set
            {
                if (this.website != value)
                {
                    this.website = value;
                    this.OnPropertyChanged("Website");
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

        public ICommand CreateCompanyCommand { get; private set; }

        private void OnCreateCompany(object obj)
        {
            var company = this.customerService.CreateCompany(this.Name, this.AddressLine, this.ZipCode, this.City, this.Country, this.Website);
            this.customerController.NavigateBackToCreateCustomer(company);
        }
    }
}
