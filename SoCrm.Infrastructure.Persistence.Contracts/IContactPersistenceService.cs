// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The ContactPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Contacts.Contracts;

    /// <summary>
    /// The ContactPersistenceService interface.
    /// </summary>
    public interface IContactPersistenceService : IPersistenceService<Contact>
    {
    }
}
