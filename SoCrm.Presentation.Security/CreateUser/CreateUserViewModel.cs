// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateUserViewModel.cs" company="Florian Amstutz">
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

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Security;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    /// <summary>
    /// The create user view model.
    /// </summary>
    public class CreateUserViewModel : ViewModelBase, ICreateUserViewModel
    {
        /// <summary>
        /// The security controller.
        /// </summary>
        private readonly ISecurityController securityController;

        /// <summary>
        /// The security service.
        /// </summary>
        private readonly ISecurityService securityService;

        /// <summary>
        /// The role.
        /// </summary>
        private Role role;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// The user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The roles.
        /// </summary>
        private ObservableCollection<Role> roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserViewModel"/> class.
        /// </summary>
        /// <param name="securityController">The security controller.</param>
        /// <param name="securityService">The security service.</param>
        public CreateUserViewModel(ISecurityController securityController, ISecurityService securityService)
        {
            this.securityController = securityController;
            this.securityService = securityService;

            this.CreateUserCommand = new CommandModel(this.OnCreateUser);

            this.Roles = new ObservableCollection<Role>(this.securityService.GetAllRoles());
        }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role
        {
            get
            {
                return this.role;
            }

            set
            {
                if (this.role != value)
                {
                    this.role = value;
                    this.OnPropertyChanged("Role");
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (this.userName != value)
                {
                    this.userName = value;
                    this.OnPropertyChanged("UserName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged("Password");
                }
            }
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
        /// Gets or sets the create user command.
        /// </summary>
        /// <value>
        /// The create user command.
        /// </value>
        public ICommand CreateUserCommand { get; set; }

        /// <summary>
        /// Called when user is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreateUser(object obj)
        {
            this.securityService.CreateUser(this.UserName, this.Password, this.Role);
            this.securityController.NavigateToUserList();
        }
    }
}
