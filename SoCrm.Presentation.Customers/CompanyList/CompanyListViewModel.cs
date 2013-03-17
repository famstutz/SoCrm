// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyListViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company list view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CompanyList
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The company list view model.
    /// </summary>
    public class CompanyListViewModel : ViewModelBase, ICompanyListViewModel
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
        /// The companies.
        /// </summary>
        private ObservableCollection<Company> companies;

        /// <summary>
        /// The countries.
        /// </summary>
        private ObservableCollection<string> countries;

        /// <summary>
        /// The search country.
        /// </summary>
        private string searchCountry;

        /// <summary>
        /// The search name.
        /// </summary>
        private string searchName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyListViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CompanyListViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.SearchCompaniesCommand = new CommandModel(this.OnSearchCompanies);

            this.Countries = new ObservableCollection<string>(this.customerService.GetAllCountries());
            this.Companies = new ObservableCollection<Company>(this.customerService.GetAllCompanies());
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
                    this.OnPropertyChanged("Companies");
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
        /// Gets or sets the search country.
        /// </summary>
        /// <value>
        /// The search country.
        /// </value>
        public string SearchCountry
        {
            get
            {
                return this.searchCountry;
            }

            set
            {
                if (this.searchCountry != value)
                {
                    this.searchCountry = value;
                    this.OnPropertyChanged("SearchCountry");
                }
            }
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
        /// Gets the search companies command.
        /// </summary>
        /// <value>
        /// The search companies command.
        /// </value>
        public ICommand SearchCompaniesCommand { get; private set; }

        /// <summary>
        /// Called when companies are searched.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSearchCompanies(object obj)
        {
            this.Companies = new ObservableCollection<Company>(this.customerService.GetCompaniesByNameAndCountry(this.SearchName, this.SearchCountry));
            this.customerController.SetLastStatus(string.Format("Found {0} companies.", this.Companies.Count));
        }
    }
}
