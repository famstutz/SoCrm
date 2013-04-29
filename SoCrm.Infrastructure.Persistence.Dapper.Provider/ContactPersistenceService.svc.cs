// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Contacts.Contracts;

    using global::Dapper;

    /// <summary>
    /// The contact persistence service.
    /// </summary>
    public class ContactPersistenceService : PersistenceServiceBase<Contact>, IContactPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPersistenceService"/> class.
        /// </summary>
        public ContactPersistenceService()
            : base("Contact.sdf", "Contacts")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the contact</returns>
        public Guid Save(Contact entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO Contacts (ObjectId, UserId, PersonId, Content, Medium, DateTime, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @UserId, @PersonId, @Content, @Medium, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                        {
                            entity.ObjectId,
                            entity.UserId,
                            entity.PersonId,
                            entity.Content,
                            Medium = (int)entity.Medium,
                            entity.DateTime,
                            entity.CreationTimeStamp,
                            entity.LastUpdateTimeStamp
                        });
                }
                else
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE Contacts SET UserId = @UserId, PersonId = @PersonId, Content = @Content, Medium = @Medium, DateTime = @DateTime, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                        {
                            entity.UserId,
                            entity.PersonId,
                            entity.Content,
                            Medium = (int)entity.Medium,
                            entity.DateTime,
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
        /// <returns>The contact.</returns>
        public Contact Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the contacts.</returns>
        public IEnumerable<Contact> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Contact entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
