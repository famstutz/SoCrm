// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The authentication service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.Authentication
{
    using System.Configuration;

    using SoCrm.Presentation.Core;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The authentication service.
    /// </summary>
    public class AuthenticationService : ViewModelBase, IAuthenticationService
    {
        /// <summary>
        /// The current user.
        /// </summary>
        private User currentUser;

        /// <summary>
        /// Gets a value indicating whether this instance is user logged on.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is user logged on; otherwise, <c>false</c>.
        /// </value>
        public bool IsUserLoggedOn
        {
            get
            {
                if (bool.Parse(ConfigurationManager.AppSettings["BypassAuthentication"]))
                {
                    return true;
                }

                return this.CurrentUser != null;
            }
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public User CurrentUser
        {
            get
            {
                return this.currentUser;
            }

            set
            {
                if (this.currentUser != value)
                {
                    this.currentUser = value;
                    this.OnPropertyChanged("CurrentUser");
                    this.OnPropertyChanged("IsUserLoggedOn");
                }
            }
        }
    }
}
