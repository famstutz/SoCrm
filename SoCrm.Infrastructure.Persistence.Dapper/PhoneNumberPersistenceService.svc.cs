// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The phone number persistence service.
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
    /// The phone number persistence service.
    /// </summary>
    public class PhoneNumberPersistenceService : PersistenceServiceBase<PhoneNumber>, IPhoneNumberPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberPersistenceService"/> class.
        /// </summary>
        public PhoneNumberPersistenceService()
            : base("Customer.sdf", "PhoneNumbers")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the phone number.</returns>
        public Guid Save(PhoneNumber entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE PhoneNumbers SET Number = @Number, ContactType = @ContactType, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.Number,
                                entity.ContactType,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO PhoneNumbers (ObjectId, Number, ContactType, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @Number, @ContactType, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.Number,
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
        /// <returns>The phone number.</returns>
        public PhoneNumber Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the phone numbers.</returns>
        public IEnumerable<PhoneNumber> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The phone number.</param>
        public void Remove(PhoneNumber entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
