// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISecurityService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Security.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    /// <summary>
    /// The security service.
    /// </summary>
    [ServiceContract]
    public interface ISecurityService
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users.</returns>
        [OperationContract]
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>All roles.</returns>
        [OperationContract]
        IEnumerable<Role> GetAllRoles();

        /// <summary>
        /// Gets the users by role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>All users matching the given role.</returns>
        [OperationContract]
        IEnumerable<User> GetUsersByRole(Role role);

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if the credentials are valid.</returns>
        [OperationContract]
        bool ValidateCredentials(string userName, string password);

        /// <summary>
        /// Gets the user by credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user of the given credentials.</returns>
        [OperationContract]
        User GetUserByCredentials(string userName, string password);

        /// <summary>
        /// Gets the user by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The user.</returns>
        [OperationContract]
        User GetUserByObjectId(Guid objectId);

        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        [OperationContract]
        void SetPassword(User user, string oldPassword, string newPassword);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="role">The role.</param>
        [OperationContract]
        void CreateUser(string userName, string password, Role role);
    }
}
