// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The company map.
    /// </summary>
    public class CompanyMap : DomainObjectMap<Company>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyMap"/> class.
        /// </summary>
        public CompanyMap()
        {
            this.Table("Companies");

            this.Map(x => x.Name);
            this.Map(x => x.Website);
            this.HasMany<Address>(x => x.Address);
        }
    }
}