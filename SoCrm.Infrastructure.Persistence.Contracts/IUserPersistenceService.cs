// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The UserPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The UserPersistenceService interface.
    /// </summary>
    public interface IUserPersistenceService : IPersistenceService<User>
    {
    }
}
