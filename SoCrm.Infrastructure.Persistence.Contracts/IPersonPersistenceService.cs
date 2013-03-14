// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersonPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The PersonPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The PersonPersistenceService interface.
    /// </summary>
    public interface IPersonPersistenceService : IPersistenceService<Person>
    {
    }
}
