// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Dapper;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The company persistence service.
    /// </summary>
    public class CompanyPersistenceService : PersistenceServiceBase<Company>, ICompanyPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyPersistenceService"/> class.
        /// </summary>
        public CompanyPersistenceService()
            : base("Customer", "Companies")
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
                var addressService = new AddressPersistenceService();
                entity.Address.ObjectId = addressService.Save(entity.Address);

                if (this.IsEntityStoredInDatabase(entity))
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
                else
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
            using (var connection = this.OpenConnection())
            {
                return
                    connection.Query<Company, Address, Company>(
                        string.Format(
                            "SELECT * FROM Companies c " +
                            "INNER JOIN Addresses a ON c.Address_ObjectId = a.ObjectId " +
                            "WHERE c.ObjectId = @ObjectId"),
                        (company, address) =>
                        {
                            company.Address = address;
                            return company;
                        },
                        new { ObjectId = objectId },
                        splitOn: "ObjectId").Single();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the companies.</returns>
        public IEnumerable<Company> GetAll()
        {
            using (var connection = this.OpenConnection())
            {
                return
                    connection.Query<Company, Address, Company>(
                        string.Format(
                            "SELECT * FROM Companies c " + 
                            "INNER JOIN Addresses a ON c.Address_ObjectId = a.ObjectId"),
                        (company, address) =>
                            {
                                company.Address = address;
                                return company;
                            },
                        splitOn: "ObjectId");
            }
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
