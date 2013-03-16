// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreatePhoneNumberViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create phone number view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreatePhoneNumber
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create phone number view model.
    /// </summary>
    public interface ICreatePhoneNumberViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        string Number { get; set; }

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
        /// Gets the create phone number command.
        /// </summary>
        /// <value>
        /// The create phone number command.
        /// </value>
        ICommand CreatePhoneNumberCommand { get; }
    }
}
