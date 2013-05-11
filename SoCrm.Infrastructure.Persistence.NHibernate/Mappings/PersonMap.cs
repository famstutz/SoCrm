// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The person map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The person map.
    /// </summary>
    public class PersonMap : DomainObjectMap<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonMap"/> class.
        /// </summary>
        public PersonMap()
        {
            this.Table("People");

            this.Map(x => x.FirstName);
            this.Map(x => x.LastName);
            this.Map(x => x.Employer);
            this.HasMany<Address>(x => x.Address);
            this.HasMany<PhoneNumber>(x => x.PhoneNumbers);
            this.HasMany<EMailAddress>(x => x.EMailAddresses);
        }
    }
}