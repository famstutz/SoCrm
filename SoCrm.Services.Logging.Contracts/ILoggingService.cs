namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        IEnumerable<LogEvent> GetAllLogEvents();
        [OperationContract]
        IEnumerable<Severity> GetAllSeverities();
        [OperationContract]
        IEnumerable<LogEvent> GetLogEventsBySeverity(Severity severity);
        [OperationContract]
        LogEvent GetLogEventByObjectId(Guid objectId);
        [OperationContract]
        void LogEvent(string message, Severity severity, DateTime timeStamp);
    }
 }
