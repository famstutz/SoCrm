// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The address map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The address map.
    /// </summary>
    public class AddressMap : DomainObjectMap<Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressMap"/> class.
        /// </summary>
        public AddressMap()
        {
            this.Table("Addresses");

            this.Map(x => x.AddressLine);
            this.Map(x => x.ZipCode);
            this.Map(x => x.City);
            this.Map(x => x.Country);
        }
    }
}