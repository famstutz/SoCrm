// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoggingService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The logging service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    /// <summary>
    /// The logging service.
    /// </summary>
    [ServiceContract]
    public interface ILoggingService
    {
        /// <summary>
        /// Gets all log events.
        /// </summary>
        /// <returns>The log events.</returns>
        [OperationContract]
        IEnumerable<LogEvent> GetAllLogEvents();
        
        /// <summary>
        /// Gets all severities.
        /// </summary>
        /// <returns>The severities.</returns>
        [OperationContract]
        IEnumerable<Severity> GetAllSeverities();

        /// <summary>
        /// Gets the log events by severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <returns>The log events.</returns>
        [OperationContract]
        IEnumerable<LogEvent> GetLogEventsBySeverity(Severity severity);

        /// <summary>
        /// Gets the log event by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The log event.</returns>
        [OperationContract]
        LogEvent GetLogEventByObjectId(Guid objectId);

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>The created log event.</returns>
        [OperationContract]
        LogEvent LogEvent(string message, Severity severity, DateTime timeStamp);
    }
 }
