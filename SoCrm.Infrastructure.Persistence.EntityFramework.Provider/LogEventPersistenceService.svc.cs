namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Logging.Contracts;

    public class LogEventPersistenceService : PersistenceServiceBase<LogEvent>, ILogEventPersistenceService
    {
    }
}
