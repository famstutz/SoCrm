namespace SoCrm.Presentation.Customers.CreateCustomer
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    public interface ICreateCustomerViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        /// <value>
        /// The address line.
        /// </value>
        string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        ObservableCollection<string> Countries { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        ObservableCollection<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        Company Company { get; set; }

        ObservableCollection<EMailAddress> EMailAddresses { get; set; }
        EMailAddress SelectedEMailAddress { get; set; }
        ObservableCollection<PhoneNumber> PhoneNumbers { get; set; }
        PhoneNumber SelectedPhoneNumber { get; set; }

        /// <summary>
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        ICommand CreateCustomerCommand { get; }

        ICommand CreateCompanyCommand { get; }

        ICommand CreateEMailAddressCommand { get; }
        ICommand CreatePhoneNumberCommand { get; }

        ICommand DeleteEMailAddressCommand { get; }
        ICommand DeletePhoneNumberCommand { get; }
    }
}
