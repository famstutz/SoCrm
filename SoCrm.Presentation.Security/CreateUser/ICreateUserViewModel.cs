// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateUserViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.CreateUser
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The create user view model.
    /// </summary>
    public interface ICreateUserViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        Role Role { get; set; }

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
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        ObservableCollection<Role> Roles { get; set; }

        /// <summary>
        /// Gets the create user command.
        /// </summary>
        /// <value>
        /// The create user command.
        /// </value>
        ICommand CreateUserCommand { get; }
    }
}
