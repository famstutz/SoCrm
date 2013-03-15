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

    using SoCrm.Contracts;

    /// <summary>
    /// The person.
    /// </summary>
    [DataContract]
    public class Person : DomainObject
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the employer.
        /// </summary>
        /// <value>
        /// The employer.
        /// </value>
        [DataMember]
        public Company Employer { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public Address Address { get; set; }
        
        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        [DataMember]
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        
        /// <summary>
        /// Gets or sets the E mail addresses.
        /// </summary>
        /// <value>
        /// The E mail addresses.
        /// </value>
        [DataMember]
        public IEnumerable<EMailAddress> EMailAddresses { get; set; }
    }
}
