// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The logging service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Logging.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Services.Logging.Provider.LogEventPersistence;

    /// <summary>
    /// The logging service.
    /// </summary>
    public sealed class LoggingService : ILoggingService
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly IPersistenceServiceOf_LogEvent client;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingService" /> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public LoggingService(IPersistenceServiceOf_LogEvent client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets all log events.
        /// </summary>
        /// <returns>
        /// The log events.
        /// </returns>
        public IEnumerable<LogEvent> GetAllLogEvents()
        {
            return this.client.GetAll();
        }

        /// <summary>
        /// Gets all severities.
        /// </summary>
        /// <returns>
        /// The severities.
        /// </returns>
        public IEnumerable<Severity> GetAllSeverities()
        {
            return Enum.GetValues(typeof(Severity)).Cast<Severity>();
        }

        /// <summary>
        /// Gets the log events by severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <returns>
        /// The log events.
        /// </returns>
        public IEnumerable<LogEvent> GetLogEventsBySeverity(Severity severity)
        {
            return this.client.GetAll().Where(le => le.Severity == severity);
        }

        /// <summary>
        /// Gets the log event by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The log event.
        /// </returns>
        public LogEvent GetLogEventByObjectId(Guid objectId)
        {
            return this.client.Get(objectId);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>
        /// The created log event.
        /// </returns>
        public LogEvent LogEvent(string message, Severity severity, DateTime timeStamp)
        {
            var logEventObjectId = this.client.Save(new LogEvent { Message = message, Severity = severity, TimeStamp = timeStamp });
            return this.client.Get(logEventObjectId);
        }
    }
}
