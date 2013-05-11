// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   Defines the PhoneNumberPersistenceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The address persistence service.
    /// </summary>
    public class PhoneNumberPersistenceService : PersistenceServiceBase<PhoneNumber>, IPhoneNumberPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberPersistenceService"/> class.
        /// </summary>
        public PhoneNumberPersistenceService()
            : base("Customer")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the phone number.</returns>
        public Guid Save(PhoneNumber entity)
        {
            return this.SaveOrUpdateEntity(entity);
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>A phone number.</returns>
        public PhoneNumber Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the phone numbers.</returns>
        public IEnumerable<PhoneNumber> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(PhoneNumber entity)
        {
            this.RemoveEntity(entity);
        }
    }
}