// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The data service interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Contracts;

    /// <summary>
    /// The data service interface.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The object id.</returns>
        Guid Create(IDomainObject obj);

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>The domain objects.</returns>
        IEnumerable<IDomainObject> Read();

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The domain object.</returns>
        IDomainObject Read(Guid objectId);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Update(IDomainObject obj);

        /// <summary>
        /// Deletes the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        void Delete(Guid objectId);
    }
}
