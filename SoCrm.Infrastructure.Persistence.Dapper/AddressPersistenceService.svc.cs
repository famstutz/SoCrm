// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The address persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    using global::Dapper;

    /// <summary>
    /// The address persistence service.
    /// </summary>
    public class AddressPersistenceService : PersistenceServiceBase<Address>, IAddressPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressPersistenceService"/> class.
        /// </summary>
        public AddressPersistenceService()
            : base("Customer.sdf", "Addresses")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the address.</returns>
        public Guid Save(Address entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE Addresses SET AddressLine = @AddressLine, ZipCode = @ZipCode, City = @City, Country = @Country, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.AddressLine,
                                entity.ZipCode,
                                entity.City,
                                entity.Country,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO Addresses (ObjectId, AddressLine, ZipCode, City, Country, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @AddressLine, @ZipCode, @City, @Country, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.AddressLine,
                                entity.ZipCode,
                                entity.City,
                                entity.Country,
                                entity.CreationTimeStamp,
                                entity.LastUpdateTimeStamp
                            });
                }
            }

            return entity.ObjectId;
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The address.</returns>
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
