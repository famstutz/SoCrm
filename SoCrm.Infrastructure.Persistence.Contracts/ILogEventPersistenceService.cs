// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogEventPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The LogEventPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The LogEventPersistenceService interface.
    /// </summary>
    public interface ILogEventPersistenceService : IPersistenceService<LogEvent>
    {
    }
}
