// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceServiceBase.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The persistence service base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;

    /// <summary>
    /// The persistence service base class.
    /// </summary>
    /// <typeparam name="T">The domain object.</typeparam>
    public abstract class PersistenceServiceBase<T> : IPersistenceService<T> where T : IDomainObject
    {
        /// <summary>
        /// The data service.
        /// </summary>
        private readonly IDataService dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceServiceBase{T}"/> class.
        /// </summary>
        protected PersistenceServiceBase()
        {
            this.dataService = DataServiceFactory.Create(typeof(T));
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(T entity)
        {
            if (entity.CreationTimeStamp == default(DateTime))
            {
                this.dataService.Create(entity);
            }
            else
            {
                this.dataService.Update(entity);
            }
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The entity.</returns>
        public T Get(Guid objectId)
        {
            return (T)this.dataService.Read(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the entities.</returns>
        public IEnumerable<T> GetAll()
        {
            return this.dataService.Read().Cast<T>();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            this.dataService.Delete(entity.ObjectId);
        }
    }
}