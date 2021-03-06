﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingContext.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The logging context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The logging context.
    /// </summary>
    public class LoggingContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingContext"/> class.
        /// </summary>
        public LoggingContext()
            : base("Name=Logging")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Gets or sets the log events.
        /// </summary>
        /// <value>
        /// The log events.
        /// </value>
        public DbSet<LogEvent> LogEvents { get; set; }
    }
}