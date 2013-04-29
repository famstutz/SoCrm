// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Dapper;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The user persistence service.
    /// </summary>
    public class UserPersistenceService : PersistenceServiceBase, IUserPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPersistenceService"/> class.
        /// </summary>
        public UserPersistenceService()
            : base("Security.sdf")
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
                var selectReturn =
                    connection.Query<User>(
                        "SELECT ObjectId, UserName, Role, Password, CreationTimeStamp, LastUpdateTimeStamp FROM Users WHERE ObjectId = @ObjectId",
                        new { entity.ObjectId }).SingleOrDefault();

                if (selectReturn == default(User))
                {
                    connection.Execute(
                        "INSERT INTO Users (ObjectId, UserName, Role, Password, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @UserName, @Role, @Password, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.UserName,
                                Role = (int)entity.Role,
                                entity.Password,
                                entity.CreationTimeStamp,
                                entity.LastUpdateTimeStamp
                            });
                }
                else
                {
                    connection.Execute(
                        "UPDATE Users SET UserName = @UserName, Role = @Role, Password = @Password, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.UserName,
                                Role = (int)entity.Role,
                                entity.Password,
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
        /// <returns>The user.</returns>
        public User Get(Guid objectId)
        {
            using (var connection = this.OpenConnection())
            {
                return
                    connection.Query<User>(
                        "SELECT ObjectId, UserName, Role, Password, CreationTimeStamp, LastUpdateTimeStamp FROM Users WHERE ObjectId = @ObjectId",
                        new { objectId }).Single();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All users.</returns>
        public IEnumerable<User> GetAll()
        {
            using (var connection = this.OpenConnection())
            {
                return
                    connection.Query<User>(
                        "SELECT ObjectId, UserName, Role, Password, CreationTimeStamp, LastUpdateTimeStamp FROM Users");
            }
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(User entity)
        {
            using (var connection = this.OpenConnection())
            {
                connection.Execute("DELETE FROM Users WHERE ObjectId = @ObjectId", new { entity.ObjectId });
            }
        }
    }
}
