// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateEMailAddressViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create e mail address view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreateEMailAddress
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create e mail address view model.
    /// </summary>
    public interface ICreateEMailAddressViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the contact types.
        /// </summary>
        /// <value>
        /// The contact types.
        /// </value>
        ObservableCollection<ContactType> ContactTypes { get; set; }

        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        ContactType ContactType { get; set; }

        /// <summary>
        /// Gets the create E mail address command.
        /// </summary>
        /// <value>
        /// The create E mail address command.
        /// </value>
        ICommand CreateEMailAddressCommand { get; }
    }
}
