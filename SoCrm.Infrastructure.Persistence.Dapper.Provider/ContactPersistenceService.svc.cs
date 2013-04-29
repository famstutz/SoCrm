// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Contacts.Contracts;

    /// <summary>
    /// The contact persistence service.
    /// </summary>
    public class ContactPersistenceService : PersistenceServiceBase<Contact>, IContactPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPersistenceService"/> class.
        /// </summary>
        public ContactPersistenceService()
            : base("Contact.sdf", "Contacts")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the contact</returns>
        public Guid Save(Contact entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The contact.</returns>
        public Contact Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the contacts.</returns>
        public IEnumerable<Contact> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Contact entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
