namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        IEnumerable<LogEvent> GetAll();
        [OperationContract]
        IEnumerable<LogEvent> GetBySeverity(Severity severity);
        [OperationContract]
        LogEvent GetByObjectId(Guid objectId);
        [OperationContract]
        void Log(string message, Severity severity);
    }
 }
