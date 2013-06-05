// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Security.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The user.
    /// </summary>
    [DataContract]
    public class User : DomainObject
    {
        /// <summary>
        /// The user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The role.
        /// </summary>
        private Role role;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
            }
        }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [DataMember]
        public Role Role
        {
            get
            {
                return this.role;
            }

            set
            {
                this.role = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember]
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }
    }
}
