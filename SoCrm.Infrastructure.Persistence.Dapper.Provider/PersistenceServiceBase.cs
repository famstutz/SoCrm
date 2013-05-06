// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceServiceBase.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The persistence service base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlServerCe;
    using System.Linq;

    using global::Dapper;

    using SoCrm.Contracts;

    /// <summary>
    /// The persistence service base.
    /// </summary>
    /// <typeparam name="T">The entity.</typeparam>
    public abstract class PersistenceServiceBase<T> where T : IDomainObject
    {
        /// <summary>
        /// The database name.
        /// </summary>
        private readonly string databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceServiceBase{T}"/> class.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="tableName">Name of the table.</param>
        protected PersistenceServiceBase(string databaseName, string tableName)
        {
            this.databaseName = databaseName;
            this.TableName = tableName;
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        protected string TableName { get; private set; }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns>An open connection.</returns>
        protected IDbConnection OpenConnection()
        {
            var connection =
                new SqlCeConnection(
                    string.Format(@"Data Source=|DataDirectory|\{0};Persist Security Info=False", this.databaseName));
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The entity.</returns>
        protected T GetEntity(Guid objectId)
        {
            using (var connection = this.OpenConnection())
            {
                return
                    connection.Query<T>(
                        string.Format("SELECT * FROM {0} WHERE ObjectId = @ObjectId", this.TableName),
                        new { ObjectId = objectId }).Single();
            }
        }

        /// <summary>
        /// The get all entities.
        /// </summary>
        /// <returns>
        /// All the entities.
        /// </returns>
        protected IEnumerable<T> GetAllEntities()
        {
            using (var connection = this.OpenConnection())
            {
                return connection.Query<T>(string.Format("SELECT * FROM {0}", this.TableName));
            }
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void RemoveEntity(T entity)
        {
            using (var connection = this.OpenConnection())
            {
                connection.Execute(
                    string.Format("DELETE FROM {0} WHERE ObjectId = @ObjectId", this.TableName), new { entity.ObjectId });
            }
        }

        /// <summary>
        /// Determines whether [is entity stored in database] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if [is entity stored in database] [the specified entity]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsEntityStoredInDatabase(T entity)
        {
            using (var connection = this.OpenConnection())
            {
                var result =
                    connection.Query<T>(
                        string.Format("SELECT * FROM {0} WHERE ObjectId = @ObjectId", this.TableName),
                        new { entity.ObjectId }).SingleOrDefault();

                if (result == null)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Prepares the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotSupportedException">Supplied entity is null</exception>
        protected void PrepareEntity(ref T entity)
        {
            if (entity == null)
            {
                throw new NotSupportedException("Supplied entity is null");
            }

            if (entity.ObjectId == default(Guid))
            {
                entity.ObjectId = Guid.NewGuid();
            }

            entity.CreationTimeStamp = DateTime.Now;
            entity.LastUpdateTimeStamp = DateTime.Now;
        }
    }
}