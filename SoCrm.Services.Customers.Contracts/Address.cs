// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The address.
    /// </summary>
    [DataContract]
    public class Address : DomainObject
    {
        /// <summary>
        /// The address line.
        /// </summary>
        private string addressLine;

        /// <summary>
        /// The zip code.
        /// </summary>
        private string zipCode;

        /// <summary>
        /// The city.
        /// </summary>
        private string city;

        /// <summary>
        /// The country.
        /// </summary>
        private string country;

        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        /// <value>
        /// The address line.
        /// </value>
        [DataMember]
        public string AddressLine
        {
            get
            {
                return this.addressLine;
            }

            set
            {
                this.addressLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [DataMember]
        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }

            set
            {
                this.zipCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [DataMember]
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
            }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [DataMember]
        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                this.country = value;
            }
        }
    }
}
