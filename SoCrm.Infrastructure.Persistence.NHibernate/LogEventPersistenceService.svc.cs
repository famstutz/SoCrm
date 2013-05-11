// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The log event persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The log event persistence service.
    /// </summary>
    public class LogEventPersistenceService : PersistenceServiceBase<LogEvent>, ILogEventPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventPersistenceService"/> class.
        /// </summary>
        public LogEventPersistenceService()
            : base("Logging")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the log event.</returns>
        public Guid Save(LogEvent entity)
        {
            return this.SaveOrUpdateEntity(entity);
        }

        /// <summary>
        /// Gets the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>A log event.</returns>
        public LogEvent Get(Guid objectId)
        {
            return this.GetEntity(objectId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the log events.</returns>
        public IEnumerable<LogEvent> GetAll()
        {
            return this.GetAllEntities();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(LogEvent entity)
        {
            this.RemoveEntity(entity);
        }
    }
}
