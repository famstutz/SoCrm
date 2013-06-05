// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Contacts.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The contact.
    /// </summary>
    [DataContract]
    public class Contact : DomainObject
    {
        /// <summary>
        /// The person.
        /// </summary>
        private Person person;

        /// <summary>
        /// The user.
        /// </summary>
        private User user;

        /// <summary>
        /// The date time.
        /// </summary>
        private DateTime dateTime;

        /// <summary>
        /// The medium.
        /// </summary>
        private ContactMedium medium;

        /// <summary>
        /// The content.
        /// </summary>
        private string content;

        /// <summary>
        /// The person id.
        /// </summary>
        private Guid personId;

        /// <summary>
        /// The user id.
        /// </summary>
        private Guid userId;

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        [DataMember]
        public Guid UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
            }
        }

        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        /// <value>
        /// The person id.
        /// </value>
        [DataMember]
        public Guid PersonId
        {
            get
            {
                return this.personId;
            }

            set
            {
                this.personId = value;
            }
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [DataMember]
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        /// <summary>
        /// Gets or sets the medium.
        /// </summary>
        /// <value>
        /// The medium.
        /// </value>
        [DataMember]
        public ContactMedium Medium
        {
            get
            {
                return this.medium;
            }

            set
            {
                this.medium = value;
            }
        }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        [DataMember]
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }

            set
            {
                this.dateTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [DataMember]
        public User User
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;
            }
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        [DataMember]
        public Person Person
        {
            get
            {
                return this.person;
            }

            set
            {
                this.person = value;
            }
        }
    }
}
