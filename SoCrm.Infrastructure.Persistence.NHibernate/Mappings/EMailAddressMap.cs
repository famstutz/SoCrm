// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EMailAddressMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The email address map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The email address map.
    /// </summary>
    public class EMailAddressMap : DomainObjectMap<EMailAddress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMailAddressMap"/> class.
        /// </summary>
        public EMailAddressMap()
        {
            this.Table("EMailAddresses");

            this.Map(x => x.Address);
            this.Map(x => x.ContactType).CustomType(typeof(ContactType));
        }
    }
}