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
            this.client = new LogEventPersistence.PersistenceServiceOf_LogEventClient();
        }
        public IEnumerable<LogEvent> GetAll()
        {
            return this.client.GetAll();
        }

        public IEnumerable<LogEvent> GetBySeverity(Severity severity)
        {
            return this.client.GetAll().Where(le => le.Serverity == severity);
        }

        public LogEvent GetByObjectId(Guid objectId)
        {
            return this.client.Get(objectId);
        }

        public void Log(string message, Severity severity)
        {
            var logEvent = new LogEvent() { Message = message, Serverity = severity };
            this.client.Save(logEvent);
        }
    }
}
