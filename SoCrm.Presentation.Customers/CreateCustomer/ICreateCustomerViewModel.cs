// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateCustomerViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create customer view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreateCustomer
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create customer view model.
    /// </summary>
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

        /// <summary>
        /// Gets or sets the E mail addresses.
        /// </summary>
        /// <value>
        /// The E mail addresses.
        /// </value>
        ObservableCollection<EMailAddress> EMailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the selected E mail address.
        /// </summary>
        /// <value>
        /// The selected E mail address.
        /// </value>
        EMailAddress SelectedEMailAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        ObservableCollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the selected phone number.
        /// </summary>
        /// <value>
        /// The selected phone number.
        /// </value>
        PhoneNumber SelectedPhoneNumber { get; set; }

        /// <summary>
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        ICommand CreateCustomerCommand { get; }

        /// <summary>
        /// Gets the create company command.
        /// </summary>
        /// <value>
        /// The create company command.
        /// </value>
        ICommand CreateCompanyCommand { get; }

        /// <summary>
        /// Gets the create E mail address command.
        /// </summary>
        /// <value>
        /// The create E mail address command.
        /// </value>
        ICommand CreateEMailAddressCommand { get; }

        /// <summary>
        /// Gets the create phone number command.
        /// </summary>
        /// <value>
        /// The create phone number command.
        /// </value>
        ICommand CreatePhoneNumberCommand { get; }

        /// <summary>
        /// Gets the delete E mail address command.
        /// </summary>
        /// <value>
        /// The delete E mail address command.
        /// </value>
        ICommand DeleteEMailAddressCommand { get; }

        /// <summary>
        /// Gets the delete phone number command.
        /// </summary>
        /// <value>
        /// The delete phone number command.
        /// </value>
        ICommand DeletePhoneNumberCommand { get; }
    }
}
