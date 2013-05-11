// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Contacts.Contracts;

    /// <summary>
    /// The contact map.
    /// </summary>
    public class ContactMap : DomainObjectMap<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMap"/> class.
        /// </summary>
        public ContactMap()
        {
            this.Table("Contacts");

            this.Map(x => x.UserId);
            this.Map(x => x.PersonId);
            this.Map(x => x.Content);
            this.Map(x => x.Medium);
            this.Map(x => x.DateTime);
            this.Map(x => x.User);
            this.Map(x => x.Person);
        }
    }
}