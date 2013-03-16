// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCompanyViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create company view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreateCompany
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create company view model.
    /// </summary>
    public class CreateCompanyViewModel : ViewModelBase, ICreateCompanyViewModel
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
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The website.
        /// </summary>
        private string website;

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
        /// Initializes a new instance of the <see cref="CreateCompanyViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CreateCompanyViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreateCompanyCommand = new CommandModel(this.OnCreateCompany);

            this.Countries = new ObservableCollection<string>(this.customerService.GetAllCountries());
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
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

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
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
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        public ICommand CreateCompanyCommand { get; private set; }

        /// <summary>
        /// Called when company is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreateCompany(object obj)
        {
            var company = this.customerService.CreateCompany(this.Name, this.AddressLine, this.ZipCode, this.City, this.Country, this.Website);
            this.customerController.NavigateBackToCreateCustomer(company);
        }
    }
}
