namespace SoCrm.Services.Logging.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Services.Logging.Provider.LogEventPersistence;

    public class LoggingService : ILoggingService
    {
        private PersistenceServiceOf_LogEventClient client;

        public LoggingService()
        {
            this.client = new PersistenceServiceOf_LogEventClient();
        }
        public IEnumerable<LogEvent> GetAllLogEvents()
        {
            return this.client.GetAll();
        }

        public IEnumerable<LogEvent> GetLogEventsBySeverity(Severity severity)
        {
            return this.client.GetAll().Where(le => le.Severity == severity);
        }

        public LogEvent GetLogEventByObjectId(Guid objectId)
        {
            return this.client.Get(objectId);
        }

        public void LogEvent(string message, Severity severity, DateTime timeStamp)
        {
            var logEvent = new LogEvent() { Message = message, Severity = severity, TimeStamp = timeStamp };
            this.client.Save(logEvent);
        }
    }
}
