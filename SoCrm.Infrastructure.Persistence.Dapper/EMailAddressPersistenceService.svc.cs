// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EMailAddressPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The e mail address persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper
{
    using System;
    using System.Collections.Generic;

    using global::Dapper;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The e mail address persistence service.
    /// </summary>
    public class EMailAddressPersistenceService : PersistenceServiceBase<EMailAddress>, IEMailAddressPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMailAddressPersistenceService"/> class.
        /// </summary>
        public EMailAddressPersistenceService()
            : base("Customer.sdf", "EMailAddresses")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the email address.</returns>
        public Guid Save(EMailAddress entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE EMailAddresses SET Address = @Address, ContactType = @ContactType, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.Address,
                                entity.ContactType,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO EMailAddresses (ObjectId, Address, ContactType, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @Address, @ContactType, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.Address,
                                entity.ContactType,
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
        /// <returns>The email address.</returns>
        public EMailAddress Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the email addresses.</returns>
        public IEnumerable<EMailAddress> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(EMailAddress entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
