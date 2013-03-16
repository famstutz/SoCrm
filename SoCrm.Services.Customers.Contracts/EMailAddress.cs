// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EMailAddress.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The email address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Contracts;

    /// <summary>
    /// The email address.
    /// </summary>
    [DataContract]
    public class EMailAddress : DomainObject
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        [DataMember]
        public ContactType ContactType { get; set; }
    }
}
