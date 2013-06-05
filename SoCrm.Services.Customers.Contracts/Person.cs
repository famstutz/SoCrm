// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The person.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The person.
    /// </summary>
    [DataContract]
    public class Person : DomainObject
    {
        /// <summary>
        /// The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The employer.
        /// </summary>
        private Company employer;

        /// <summary>
        /// The address.
        /// </summary>
        private Address address;

        /// <summary>
        /// The phone numbers.
        /// </summary>
        private ICollection<PhoneNumber> phoneNumbers;

        /// <summary>
        /// The e mail addresses.
        /// </summary>
        private ICollection<EMailAddress> emailAddresses;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [DataMember]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [DataMember]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the employer.
        /// </summary>
        /// <value>
        /// The employer.
        /// </value>
        [DataMember]
        public Company Employer
        {
            get
            {
                return this.employer;
            }

            set
            {
                this.employer = value;
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public Address Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            set
            {
                this.phoneNumbers = value;
            }
        }

        /// <summary>
        /// Gets or sets the E mail addresses.
        /// </summary>
        /// <value>
        /// The E mail addresses.
        /// </value>
        [DataMember]
        public ICollection<EMailAddress> EMailAddresses
        {
            get
            {
                return this.emailAddresses;
            }

            set
            {
                this.emailAddresses = value;
            }
        }
    }
}
