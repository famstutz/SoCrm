// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NHibernateHelper.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The NHibernate helper class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// The NHibernate helper class.
    /// </summary>
    public static class NHibernateHelper
    {
        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns>The session factory.</returns>
        public static ISessionFactory CreateSessionFactory(string databaseName)
        {
            return
                Fluently.Configure()
                        .Database(
                            MsSqlCeConfiguration.Standard.ConnectionString(
                                string.Format(
                                    @"Data Source=|DataDirectory|\{0}.sdf;Persist Security Info=False", databaseName)))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LogEventPersistenceService>())
                        .ExposeConfiguration(BuildSchema)
                        .BuildSessionFactory();
        }

        /// <summary>
        /// Builds the schema.
        /// </summary>
        /// <param name="config">The config.</param>
        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, false);
        }
    }
}