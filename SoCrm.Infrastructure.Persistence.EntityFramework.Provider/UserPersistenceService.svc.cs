// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The UserPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The UserPersistenceService.
    /// </summary>
    public class UserPersistenceService : PersistenceServiceBase<User>, IUserPersistenceService
    {
    }
}