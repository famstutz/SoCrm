// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerListViewModel.cs" company="Florian Amstutz">
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

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The customer list view model.
    /// </summary>
    public interface ICustomerListViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the name of the search.
        /// </summary>
        /// <value>
        /// The name of the search.
        /// </value>
        string SearchName { get; set; }

        /// <summary>
        /// Gets or sets the search company.
        /// </summary>
        /// <value>
        /// The search company.
        /// </value>
        string SearchCompany { get; set; }

        /// <summary>
        /// Gets the search customers command.
        /// </summary>
        /// <value>
        /// The search customers command.
        /// </value>
        ICommand SearchCustomersCommand { get; }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        ObservableCollection<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the selected person.
        /// </summary>
        /// <value>
        /// The selected person.
        /// </value>
        Person SelectedPerson { get; set; }

        /// <summary>
        /// Gets the delete customer command.
        /// </summary>
        /// <value>
        /// The delete customer command.
        /// </value>
        ICommand DeleteCustomerCommand { get; }
    }
}
