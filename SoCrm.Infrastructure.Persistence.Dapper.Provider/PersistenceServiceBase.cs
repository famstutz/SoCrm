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
    using System.Data;
    using System.Data.SqlServerCe;

    /// <summary>
    /// The persistence service base.
    /// </summary>
    public abstract class PersistenceServiceBase
    {
        /// <summary>
        /// The database name.
        /// </summary>
        private readonly string databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceServiceBase"/> class.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        protected PersistenceServiceBase(string databaseName)
        {
            this.databaseName = databaseName;
        }

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
    }
}