// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The log event persistence service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Dapper
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Logging.Contracts;

    using global::Dapper;

    /// <summary>
    /// The log event persistence service.
    /// </summary>
    public class LogEventPersistenceService : PersistenceServiceBase<LogEvent>, ILogEventPersistenceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventPersistenceService"/> class.
        /// </summary>
        public LogEventPersistenceService()
            : base("Logging.sdf", "LogEvents")
        {
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The id of the log event.</returns>
        public Guid Save(LogEvent entity)
        {
            using (var connection = this.OpenConnection())
            {
                if (this.IsEntityStoredInDatabase(entity))
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    connection.Execute(
                        "UPDATE LogEvents SET Message = @Message, Severity = @Severity, TimeStamp = @TimeStamp, LastUpdateTimeStamp = @LastUpdateTimeStamp WHERE ObjectId = @ObjectId",
                        new
                            {
                                entity.Message,
                                entity.Severity,
                                entity.TimeStamp,
                                entity.LastUpdateTimeStamp,
                                entity.ObjectId
                            });
                }
                else
                {
                    this.PrepareEntity(ref entity);

                    connection.Execute(
                        "INSERT INTO LogEvents (ObjectId, Message, Severity, TimeStamp, CreationTimeStamp, LastUpdateTimeStamp) VALUES (@ObjectId, @Message, @Severity, @TimeStamp, @CreationTimeStamp, @LastUpdateTimeStamp)",
                        new
                            {
                                entity.ObjectId,
                                entity.Message,
                                entity.Severity,
                                entity.TimeStamp,
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
        /// <returns>The log event.</returns>
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
