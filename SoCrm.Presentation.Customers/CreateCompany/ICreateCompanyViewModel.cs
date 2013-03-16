namespace SoCrm.Presentation.Customers.CreateCompany
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;

    public interface ICreateCompanyViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        string Website { get; set; }

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
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        ICommand CreateCompanyCommand { get; }
    }
}
