// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISecurityController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security
{
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The security controller.
    /// </summary>
    public interface ISecurityController : IController
    {
        /// <summary>
        /// Navigates to user list.
        /// </summary>
        void NavigateToUserList();

        /// <summary>
        /// Navigates to create user.
        /// </summary>
        void NavigateToCreateUser();

        /// <summary>
        /// Navigates to set password.
        /// </summary>
        /// <param name="user">The user.</param>
        void NavigateToSetPassword(User user);

        /// <summary>
        /// Navigates to authentication.
        /// </summary>
        void NavigateToAuthentication();
    }
}
