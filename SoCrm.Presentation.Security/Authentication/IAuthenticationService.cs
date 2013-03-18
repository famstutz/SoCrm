// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The authentication service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.Authentication
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The authentication service.
    /// </summary>
    public interface IAuthenticationService : IViewModelBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance is user logged on.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is user logged on; otherwise, <c>false</c>.
        /// </value>
        bool IsUserLoggedOn { get; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        User CurrentUser { get; set; }
    }
}
