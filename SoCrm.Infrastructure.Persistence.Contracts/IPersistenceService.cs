// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The PersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using SoCrm.Contracts;

    /// <summary>
    /// The PersistenceService interface.
    /// </summary>
    /// <typeparam name="T">The domain object.</typeparam>
    [ServiceContract]
    public interface IPersistenceService<T> where T : IDomainObject
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The object id.</returns>
        [OperationContract]
        Guid Save(T entity);

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The entity.</returns>
        [OperationContract]
        T Get(Guid objectId);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>All the entities.</returns>
        [OperationContract]
        IEnumerable<T> GetAll();

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [OperationContract]
        void Remove(T entity);
    }
}
