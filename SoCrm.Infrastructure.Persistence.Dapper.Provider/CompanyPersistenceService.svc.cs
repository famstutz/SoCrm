// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    using global::Dapper;

    /// <summary>
    /// The company persistence service.
    /// </summary>
    public class CompanyPersistenceService : PersistenceServiceBase<Company>, ICompanyPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyPersistenceService"/> class.
        /// </summary>
        public CompanyPersistenceService()
            : base("Customer.sdf", "Companies")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the company.</returns>
        public Guid Save(Company entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO Companies (ObjectId, Name, Website, Address_ObjectId, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @Name, @Website, @AddressObjectId, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                        {
                            entity.ObjectId,
                            entity.Name,
                            entity.Website,
                            AddressObjectId = entity.Address.ObjectId,
                            entity.CreationTimeStamp,
                            entity.LastUpdateTimeStamp
                        });
                }
                else
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE Companies SET Name = @Name, Website = @Website, Address_ObjectId = @AddressObjectId, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                        {
                            entity.Name,
                            entity.Website,
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
        /// <returns>The company.</returns>
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
