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
    using System.Linq;

    using global::Dapper;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Contacts.Contracts;

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
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE Contacts SET UserId = @UserId, PersonId = @PersonId, Content = @Content, Medium = @Medium, DateTime = @DateTime, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.UserId,
                                entity.PersonId,
                                entity.Content,
                                entity.Medium,
                                entity.DateTime,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO Contacts (ObjectId, UserId, PersonId, Content, Medium, DateTime, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @UserId, @PersonId, @Content, @Medium, @DateTime, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.UserId,
                                entity.PersonId,
                                entity.Content,
                                entity.Medium,
                                entity.DateTime,
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
        /// <returns>The contact.</returns>
        public Contact Get(Guid objectId)
        {
            var userPersistenceService = new UserPersistenceService();
            var personPersistenceService = new PersonPersistenceService();

            var contact = this.GetEntity(objectId);
            contact.User = userPersistenceService.Get(contact.UserId);
            contact.Person = personPersistenceService.Get(contact.PersonId);

            return contact;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the contacts.</returns>
        public IEnumerable<Contact> GetAll()
        {
            var userPersistenceService = new UserPersistenceService();
            var personPersistenceService = new PersonPersistenceService();

            var contacts = this.GetAllEntities().ToList();
            foreach (var contact in contacts)
            {
                contact.User = userPersistenceService.Get(contact.UserId);
                contact.Person = personPersistenceService.Get(contact.PersonId);
            }

            return contacts;
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
