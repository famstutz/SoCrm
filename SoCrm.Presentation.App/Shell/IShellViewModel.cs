// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShellViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The shell view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App.Shell
{
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The shell view model.
    /// </summary>
    public interface IShellViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets the user list command.
        /// </summary>
        /// <value>
        /// The user list command.
        /// </value>
        ICommand UserListCommand { get; }

        /// <summary>
        /// Gets the create user command.
        /// </summary>
        /// <value>
        /// The create user command.
        /// </value>
        ICommand CreateUserCommand { get; }

        /// <summary>
        /// Gets the customer list command.
        /// </summary>
        /// <value>
        /// The customer list command.
        /// </value>
        ICommand CustomerListCommand { get; }

        /// <summary>
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        ICommand CreateCustomerCommand { get; }

        /// <summary>
        /// Gets the main region.
        /// </summary>
        /// <value>
        /// The main region.
        /// </value>
        IRegion MainRegion { get; }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        void Show();
    }
}
