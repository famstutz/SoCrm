// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The LogEventPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The LogEventPersistenceService.
    /// </summary>
    public class LogEventPersistenceService : PersistenceServiceBase<LogEvent>, ILogEventPersistenceService
    {
    }
}
