// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Security.Contracts;

    using global::Dapper;

    /// <summary>
    /// The user persistence service.
    /// </summary>
    public class UserPersistenceService : PersistenceServiceBase<User>, IUserPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPersistenceService"/> class.
        /// </summary>
        public UserPersistenceService()
            : base("Security.sdf", "Users")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id.</returns>
        public Guid Save(User entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE Users SET UserName = @UserName, Role = @Role, Password = @Password, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.UserName,
                                entity.Role,
                                entity.Password,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO Users (ObjectId, UserName, Role, Password, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @UserName, @Role, @Password, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.UserName,
                                entity.Role,
                                entity.Password,
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
        /// <returns>The user.</returns>
        public User Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All users.</returns>
        public IEnumerable<User> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(User entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
