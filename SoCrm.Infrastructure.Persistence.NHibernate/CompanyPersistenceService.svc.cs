// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   Defines the CompanyPersistenceService type.
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
    public class CompanyPersistenceService : PersistenceServiceBase<Company>, ICompanyPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyPersistenceService"/> class.
        /// </summary>
        public CompanyPersistenceService()
            : base("Customer")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the company.</returns>
        public Guid Save(Company entity)
        {
            return this.SaveOrUpdateEntity(entity);
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>A company.</returns>
        public Company Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the companies.</returns>
        public IEnumerable<Company> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Company entity)
        {
            this.RemoveEntity(entity);
        }
    }
}