// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticationViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The authentication view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.Authentication
{
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The authentication view model.
    /// </summary>
    public interface IAuthenticationViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets the log on command.
        /// </summary>
        /// <value>
        /// The log on command.
        /// </value>
        ICommand LogOnCommand { get; }
    }
}
