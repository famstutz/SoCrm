// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The log event data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Core.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;
    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The log event data service.
    /// </summary>
    public class LogEventDataService : IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The object id.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public Guid Create(IDomainObject obj)
        {
            var logEvent = obj as LogEvent;
            if (logEvent == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (logEvent.ObjectId == default(Guid))
            {
                logEvent.ObjectId = Guid.NewGuid();
            }

            logEvent.CreationTimeStamp = DateTime.Now;
            logEvent.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new LoggingContext())
            {
                db.LogEvents.Add(logEvent);
                db.SaveChanges();
            }

            return logEvent.ObjectId;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// The log events.
        /// </returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new LoggingContext())
            {
                return db.LogEvents.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The log event.
        /// </returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new LoggingContext())
            {
                return db.LogEvents.Single(le => le.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var logEvent = obj as LogEvent;
            if (logEvent == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new LoggingContext())
            {
                var readLogEvent = db.LogEvents.Single(le => le.ObjectId.Equals(logEvent.ObjectId));
                readLogEvent.Message = logEvent.Message;
                readLogEvent.Severity = logEvent.Severity;
                readLogEvent.TimeStamp = logEvent.TimeStamp;
                readLogEvent.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        public void Delete(Guid objectId)
        {
            using (var db = new LoggingContext())
            {
                db.LogEvents.Remove(this.Read(objectId) as LogEvent);
                db.SaveChanges();
            }
        }
    }
}