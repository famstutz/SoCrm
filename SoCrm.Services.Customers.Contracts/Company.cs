// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The company.
    /// </summary>
    [DataContract]
    public class Company : DomainObject
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The address.
        /// </summary>
        private Address address;

        /// <summary>
        /// The website.
        /// </summary>
        private string website;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
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
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        [DataMember]
        public string Website
        {
            get
            {
                return this.website;
            }

            set
            {
                this.website = value;
            }
        }
    }
}
