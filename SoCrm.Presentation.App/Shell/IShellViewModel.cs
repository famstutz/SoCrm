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
    using System;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;

    /// <summary>
    /// The shell view model.
    /// </summary>
    public interface IShellViewModel : IViewModelBase
    {
        /// <summary>
        /// Occurs when closing.
        /// </summary>
        event EventHandler Closing;

        /// <summary>
        /// Gets a value indicating whether this instance is logged on.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is logged on; otherwise, <c>false</c>.
        /// </value>
        bool IsLoggedOn { get; }

        /// <summary>
        /// Gets or sets the status bar service.
        /// </summary>
        /// <value>
        /// The status bar service.
        /// </value>
        IStatusBarService StatusBarService { get; set; }

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
        /// Gets the exit command.
        /// </summary>
        /// <value>
        /// The exit command.
        /// </value>
        ICommand ExitCommand { get; }

        /// <summary>
        /// Gets the company list command.
        /// </summary>
        /// <value>
        /// The company list command.
        /// </value>
        ICommand CompanyListCommand { get; }

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
