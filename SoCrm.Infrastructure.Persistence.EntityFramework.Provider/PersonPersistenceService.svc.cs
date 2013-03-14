// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The PersonPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The PersonPersistenceService.
    /// </summary>
    public class PersonPersistenceService : PersistenceServiceBase<Person>, IPersonPersistenceService
    {
    }
}
