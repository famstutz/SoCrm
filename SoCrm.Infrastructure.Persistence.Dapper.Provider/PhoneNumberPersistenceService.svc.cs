// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The phone number persistence service.
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
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO PhoneNumbers (ObjectId, Number, ContactType, Person_ObjectId, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @Number, @ContactType, @PersonObjectId, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.Number,
                                ContactType = (int)entity.ContactType,
                                //PersonObjectId = entity.???,
                                entity.CreationTimeStamp,
                                entity.LastUpdateTimeStamp
                            });
                }
                else
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE PhoneNumbers SET Number = @Number, ContactType = @ContactType, Person_ObjectId = @PersonObjectId, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.Number,
                                ContactType = (int)entity.ContactType,
                                //entity.???,
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
