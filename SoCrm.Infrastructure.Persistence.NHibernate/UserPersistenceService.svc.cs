// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   Defines the UserPersistenceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The address persistence service.
    /// </summary>
    public class UserPersistenceService : PersistenceServiceBase<User>, IUserPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPersistenceService"/> class.
        /// </summary>
        public UserPersistenceService()
            : base("Security")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the user.</returns>
        public Guid Save(User entity)
        {
            return this.SaveOrUpdateEntity(entity);
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>A user.</returns>
        public User Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the users.</returns>
        public IEnumerable<User> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(User entity)
        {
            this.RemoveEntity(entity);
        }
    }
}