// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetPasswordViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The set password view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.SetPassword
{
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    /// <summary>
    /// The set password view model.
    /// </summary>
    public class SetPasswordViewModel : ViewModelBase, ISetPasswordViewModel
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
        /// The user.
        /// </summary>
        private User user;

        /// <summary>
        /// The old password.
        /// </summary>
        private string oldPassword;

        /// <summary>
        /// The new password.
        /// </summary>
        private string newPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPasswordViewModel"/> class.
        /// </summary>
        /// <param name="securityController">The security controller.</param>
        /// <param name="securityService">The security service.</param>
        /// <param name="user">The user.</param>
        public SetPasswordViewModel(ISecurityController securityController, ISecurityService securityService, User user)
        {
            this.securityController = securityController;
            this.securityService = securityService;
            this.User = user;

            this.SetPasswordCommand = new CommandModel(this.OnSetPassword);
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User
        {
            get
            {
                return this.user;
            }

            set
            {
                if (this.user != value)
                {
                    this.user = value;
                    this.OnPropertyChanged("User");
                }
            }
        }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        public string OldPassword
        {
            get
            {
                return this.oldPassword;
            }

            set
            {
                if (this.oldPassword != value)
                {
                    this.oldPassword = value;
                    this.OnPropertyChanged("OldPassword");
                }
            }
        }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword
        {
            get
            {
                return this.newPassword;
            }

            set
            {
                if (this.newPassword != value)
                {
                    this.newPassword = value;
                    this.OnPropertyChanged("NewPassword");
                }
            }
        }

        /// <summary>
        /// Gets the set password command.
        /// </summary>
        /// <value>
        /// The set password command.
        /// </value>
        public ICommand SetPasswordCommand { get; private set; }

        /// <summary>
        /// Called when the password is set.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSetPassword(object obj)
        {
            this.securityService.SetPassword(this.User, this.OldPassword, this.NewPassword);
            this.securityController.NavigateToUserList();
        }
    }
}
