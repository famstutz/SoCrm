// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumber.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The phone number.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The phone number.
    /// </summary>
    [DataContract]
    public class PhoneNumber : DomainObject
    {
        /// <summary>
        /// The number.
        /// </summary>
        private string number;

        /// <summary>
        /// The contact type.
        /// </summary>
        private ContactType contactType;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [DataMember]
        public string Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        [DataMember]
        public ContactType ContactType
        {
            get
            {
                return this.contactType;
            }

            set
            {
                this.contactType = value;
            }
        }
    }
}
