// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The phone number map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The phone number map.
    /// </summary>
    public class PhoneNumberMap : DomainObjectMap<PhoneNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberMap"/> class.
        /// </summary>
        public PhoneNumberMap()
        {
            this.Table("PhoneNumbers");

            this.Map(x => x.Number);
            this.Map(x => x.ContactType).CustomType<ContactType>();
        }
    }
}