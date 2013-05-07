// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingConfiguration.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The logging configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Logging
{
    using System.Data.Entity.Migrations;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;

    /// <summary>
    /// The logging configuration.
    /// </summary>
    internal sealed class LoggingConfiguration : DbMigrationsConfiguration<LoggingContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingConfiguration"/> class.
        /// </summary>
        public LoggingConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
