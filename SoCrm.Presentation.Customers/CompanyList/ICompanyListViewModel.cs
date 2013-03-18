// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompanyListViewModel.cs" company="Florian Amstutz">
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

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The company list view model.
    /// </summary>
    public interface ICompanyListViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        ObservableCollection<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        ObservableCollection<string> Countries { get; set; }

        /// <summary>
        /// Gets or sets the search country.
        /// </summary>
        /// <value>
        /// The search country.
        /// </value>
        string SearchCountry { get; set; }

        /// <summary>
        /// Gets or sets the name of the search.
        /// </summary>
        /// <value>
        /// The name of the search.
        /// </value>
        string SearchName { get; set; }

        /// <summary>
        /// Gets the search companies command.
        /// </summary>
        /// <value>
        /// The search companies command.
        /// </value>
        ICommand SearchCompaniesCommand { get; }
    }
}
