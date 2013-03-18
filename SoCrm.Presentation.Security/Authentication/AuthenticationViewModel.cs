// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The authentication view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.Authentication
{
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Security.Security;

    /// <summary>
    /// The authentication view model.
    /// </summary>
    public class AuthenticationViewModel : ViewModelBase, IAuthenticationViewModel
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
        /// The authentication service.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// The user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationViewModel"/> class.
        /// </summary>
        /// <param name="securityController">The security controller.</param>
        /// <param name="securityService">The security service.</param>
        /// <param name="authenticationService">The authentication service.</param>
        public AuthenticationViewModel(
            ISecurityController securityController,
            ISecurityService securityService,
            IAuthenticationService authenticationService)
        {
            this.securityController = securityController;
            this.securityService = securityService;
            this.authenticationService = authenticationService;

            this.LogOnCommand = new CommandModel(this.OnLogOn);
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
        /// Gets the log on command.
        /// </summary>
        /// <value>
        /// The log on command.
        /// </value>
        public ICommand LogOnCommand { get; private set; }

        /// <summary>
        /// Called when logged on.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnLogOn(object obj)
        {
            if (this.securityService.ValidateCredentials(this.UserName, this.Password))
            {
                this.authenticationService.CurrentUser = this.securityService.GetUserByCredentials(
                    this.UserName, this.Password);
                this.securityController.ClearMainRegion();
                this.securityController.SetLastStatus(string.Format("Successfully logged on as user {0}", this.UserName));
            }
            else
            { 
                this.securityController.SetLastStatus("Could not validate supplied credentials.");
            }
        }
    }
}
