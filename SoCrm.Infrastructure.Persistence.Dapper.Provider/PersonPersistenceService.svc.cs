﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The person persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;

    using global::Dapper;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The person persistence service.
    /// </summary>
    public class PersonPersistenceService : PersistenceServiceBase<Person>, IPersonPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonPersistenceService"/> class.
        /// </summary>
        public PersonPersistenceService()
            : base("Customer.sdf", "People")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the person.</returns>
        public Guid Save(Person entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO People (ObjectId, FirstName, LastName, Employer_ObjectId, Address_ObjectId, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @FirstName, @LastName, @EmployerObjectId, @AddressObjectId, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                        {
                            entity.ObjectId,
                            entity.FirstName,
                            entity.LastName,
                            EmployerObjectId = entity.Employer.ObjectId,
                            AddressObjectId = entity.Address.ObjectId,
                            entity.CreationTimeStamp,
                            entity.LastUpdateTimeStamp
                        });
                }
                else
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Employer_ObjectId = @EmployerObjectId, Address_ObjectId = @AddressObjectId, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                        {
                            entity.FirstName,
                            entity.LastName,
                            EmployerObjectId = entity.Employer.ObjectId,
                            AddressObjectId = entity.Address.ObjectId,
                            entity.LastUpdateTimeStamp,
                            entity.ObjectId
                        });
                }
            }

            return entity.ObjectId;
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The person.</returns>
        public Person Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the people.</returns>
        public IEnumerable<Person> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Person entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
