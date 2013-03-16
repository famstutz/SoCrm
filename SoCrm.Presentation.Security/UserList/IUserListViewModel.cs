// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserListViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user list view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.UserList
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The user list view model.
    /// </summary>
    public interface IUserListViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        ObservableCollection<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the name of the search user.
        /// </summary>
        /// <value>
        /// The name of the search user.
        /// </value>
        string SearchUserName { get; set; }

        /// <summary>
        /// Gets or sets the search role.
        /// </summary>
        /// <value>
        /// The search role.
        /// </value>
        Role SearchRole { get; set; }

        /// <summary>
        /// Gets or sets the selected user.
        /// </summary>
        /// <value>
        /// The selected user.
        /// </value>
        User SelectedUser { get; set; }

        /// <summary>
        /// Gets or sets the selected users.
        /// </summary>
        /// <value>
        /// The selected users.
        /// </value>
        ObservableCollection<User> SelectedUsers { get; set; }

        /// <summary>
        /// Gets the search users command.
        /// </summary>
        /// <value>
        /// The search users command.
        /// </value>
        ICommand SearchUsersCommand { get; }

        /// <summary>
        /// Gets the delete user command.
        /// </summary>
        /// <value>
        /// The delete user command.
        /// </value>
        ICommand DeleteUserCommand { get; }

        /// <summary>
        /// Gets the set password command.
        /// </summary>
        /// <value>
        /// The set password command.
        /// </value>
        ICommand SetPasswordCommand { get; }
    }
}
