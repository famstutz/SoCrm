namespace SoCrm.Services.Logging.Provider
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Services.Logging.Contracts;

    public class LoggingService : ILoggingService
    {

        public IEnumerable<LogEvent> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogEvent> Get(Severity severity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogEvent> Get(Guid objectId)
        {
            throw new NotImplementedException();
        }

        public void Log(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }

        public void Log(string message, Severity severity)
        {
            throw new NotImplementedException();
        }
    }
}
