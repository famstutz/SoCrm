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

    public class SecurityService : ISecurityService
    {
        private PersistenceServiceOf_UserClient client;

        public SecurityService()
        {
            this.client = new PersistenceServiceOf_UserClient();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.client.GetAll();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Enum.GetValues(typeof(Role)).Cast<Role>();
        }

        public IEnumerable<User> GetUsersByRole(Role role)
        {
            return this.client.GetAll().Where(u => u.Role == role);
        }

        public bool ValidateCredentials(string userName, string password)
        {
            var user = this.client.GetAll().Single(u => u.UserName == userName);
            if (user.Password == HashPassword(password))
            {
                return true;
            }
            return false;
        }

        public User GetUserByCredentials(string userName, string password)
        {
            var user = this.client.GetAll().Single(u => u.UserName == userName);
            if (user.Password == HashPassword(password))
            {
                return user;
            }
            throw new InvalidCredentialException();
        }

        public void SetPassword(User user, string oldPassword, string newPassword)
        {
            if (this.ValidateCredentials(user.UserName, oldPassword))
            {
                user.Password = HashPassword(newPassword);
                this.client.Save(user);
            }
        }

        public void CreateUser(string userName, string password, Role role)
        {
            this.client.Save(new User() { UserName = userName, Role = role, Password = HashPassword(password) });
        }

        static string HashPassword(string pasword)
        {
            var arrbyte = new byte[pasword.Length];
            var hash = new SHA256CryptoServiceProvider();
            arrbyte = hash.ComputeHash(Encoding.UTF8.GetBytes(pasword));
            return Convert.ToBase64String(arrbyte);
        }


    }
}
