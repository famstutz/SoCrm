// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Security.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Authentication;
    using System.Security.Cryptography;
    using System.Text;

    using SoCrm.Services.Security.Contracts;
    using SoCrm.Services.Security.Provider.UserPersistence;

    /// <summary>
    /// The security service.
    /// </summary>
    public sealed class SecurityService : ISecurityService, IDisposable
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly PersistenceServiceOf_UserClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        public SecurityService()
        {
            this.client = new PersistenceServiceOf_UserClient();
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>
        /// All users.
        /// </returns>
        public IEnumerable<User> GetAllUsers()
        {
            return this.client.GetAll();
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>
        /// All roles.
        /// </returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return Enum.GetValues(typeof(Role)).Cast<Role>();
        }

        /// <summary>
        /// Gets the users by role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// All users matching the given role.
        /// </returns>
        public IEnumerable<User> GetUsersByRole(Role role)
        {
            return this.client.GetAll().Where(u => u.Role == role);
        }

        /// <summary>
        /// Gets the users by role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// All users matching the given role.
        /// </returns>
        public IEnumerable<User> GetUsersByRoleAndUserName(Role role, string userName)
        {
            var users = this.GetUsersByRole(role);
            if (!string.IsNullOrWhiteSpace(userName))
            {
                users = users.Where(u => u.UserName == userName);
            }

            return users;
        }

        /// <summary>
        /// Validates the credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// True if the credentials are valid.
        /// </returns>
        public bool ValidateCredentials(string userName, string password)
        {
            var user = this.client.GetAll().Single(u => u.UserName == userName);
            if (user.Password == HashPassword(password))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the user by credentials.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The user of the given credentials.
        /// </returns>
        /// <exception cref="System.Security.Authentication.InvalidCredentialException">Thrown if the given credentials are invalid.</exception>
        public User GetUserByCredentials(string userName, string password)
        {
            var user = this.client.GetAll().Single(u => u.UserName == userName);
            if (user.Password == HashPassword(password))
            {
                return user;
            }

            throw new InvalidCredentialException();
        }

        /// <summary>
        /// Gets the user by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserByObjectId(Guid objectId)
        {
            return this.client.GetAll().Single(u => u.ObjectId == objectId);
        }

        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        public void SetPassword(User user, string oldPassword, string newPassword)
        {
            if (this.ValidateCredentials(user.UserName, oldPassword))
            {
                user.Password = HashPassword(newPassword);
                this.client.Save(user);
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="role">The role.</param>
        public void CreateUser(string userName, string password, Role role)
        {
            this.client.Save(new User { UserName = userName, Role = role, Password = HashPassword(password) });
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void DeleteUser(User user)
        {
            this.client.Remove(user);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.client.Close();
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>The hashed password.</returns>
        private static string HashPassword(string password)
        {
            var arrbyte = new byte[password.Length];
            var hash = new SHA256CryptoServiceProvider();
            arrbyte = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(arrbyte);
        }
    }
}
