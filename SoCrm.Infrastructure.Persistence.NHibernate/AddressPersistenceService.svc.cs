﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   Defines the AddressPersistenceService type.
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
    public class AddressPersistenceService : PersistenceServiceBase<Address>, IAddressPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressPersistenceService"/> class.
        /// </summary>
        public AddressPersistenceService()
            : base("Customer")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the address.</returns>
        public Guid Save(Address entity)
        {
            return this.SaveOrUpdateEntity(entity);
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>A address.</returns>
        public Address Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the addresses.</returns>
        public IEnumerable<Address> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Address entity)
        {
            this.RemoveEntity(entity);
        }
    }
}