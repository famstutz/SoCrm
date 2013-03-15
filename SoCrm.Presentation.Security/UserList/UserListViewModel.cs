// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserListViewModel.cs" company="Florian Amstutz">
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

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    /// <summary>
    /// The user list view model.
    /// </summary>
    public sealed class UserListViewModel : ViewModelBase, IUserListViewModel
    {
        /// <summary>
        /// The security controller.
        /// </summary>
        private readonly ISecurityController securityController;

        /// <summary>
        /// The security service client.
        /// </summary>
        private readonly ISecurityService securityService;

        /// <summary>
        /// The roles.
        /// </summary>
        private ObservableCollection<Role> roles;

        /// <summary>
        /// The users.
        /// </summary>
        private ObservableCollection<User> users;

        /// <summary>
        /// The search user name.
        /// </summary>
        private string searchUserName;

        /// <summary>
        /// The search role.
        /// </summary>
        private Role searchRole;

        /// <summary>
        /// The selected user.
        /// </summary>
        private User selectedUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserListViewModel" /> class.
        /// </summary>
        /// <param name="securityController">The security controller.</param>
        /// <param name="securityService">The security service.</param>
        public UserListViewModel(ISecurityController securityController, ISecurityService securityService)
        {
            this.securityController = securityController;
            this.securityService = securityService;

            this.SearchUsersCommand = new CommandModel(obj => this.Users = new ObservableCollection<User>(this.securityService.GetUsersByRoleAndUserName(this.SearchRole, this.SearchUserName)));
            this.DeleteUserCommand = new CommandModel(this.OnDeleteUser);
            this.SetPasswordCommand = new CommandModel(obj => this.securityController.NavigateToSetPassword(this.SelectedUser));
            
            this.Roles = new ObservableCollection<Role>(this.securityService.GetAllRoles());
            this.Users = new ObservableCollection<User>(this.securityService.GetUsersByRole(this.SearchRole));
        }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public ObservableCollection<Role> Roles
        {
            get
            {
                return this.roles;
            }

            set
            {
                if (this.roles != value)
                {
                    this.roles = value;
                    this.OnPropertyChanged("Roles");
                }
            }
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                if (this.users != value)
                {
                    this.users = value;
                    this.OnPropertyChanged("Users");
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the search user.
        /// </summary>
        /// <value>
        /// The name of the search user.
        /// </value>
        public string SearchUserName
        {
            get
            {
                return this.searchUserName;
            }

            set
            {
                if (this.searchUserName != value)
                {
                    this.searchUserName = value;
                    this.OnPropertyChanged("SearchUserName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the search role.
        /// </summary>
        /// <value>
        /// The search role.
        /// </value>
        public Role SearchRole
        {
            get
            {
                return this.searchRole;
            }

            set
            {
                if (this.searchRole != value)
                {
                    this.searchRole = value;
                    this.OnPropertyChanged("SearchRole");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected user.
        /// </summary>
        /// <value>
        /// The selected user.
        /// </value>
        public User SelectedUser
        {
            get
            {
                return this.selectedUser;
            }

            set
            {
                if (this.selectedUser != value)
                {
                    this.selectedUser = value;
                    this.OnPropertyChanged("SelectedUser");
                }
            }
        }

        /// <summary>
        /// Gets the search users command.
        /// </summary>
        /// <value>
        /// The search users command.
        /// </value>
        public ICommand SearchUsersCommand { get; private set; }

        /// <summary>
        /// Gets the delete user command.
        /// </summary>
        /// <value>
        /// The delete user command.
        /// </value>
        public ICommand DeleteUserCommand { get; private set; }

        /// <summary>
        /// Gets the set password command.
        /// </summary>
        /// <value>
        /// The set password command.
        /// </value>
        public ICommand SetPasswordCommand { get; private set; }

        /// <summary>
        /// Called when user is deleted.
        /// </summary>
        /// <param name="obj">The user.</param>
        private void OnDeleteUser(object obj)
        {
            var user = obj as User;
            this.securityService.DeleteUser(user);
            this.Users.Remove(user);
        }
    }
}