// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The ContactPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Contacts.Contracts;

    /// <summary>
    /// The ContactPersistenceService.
    /// </summary>
    public class ContactPersistenceService : PersistenceServiceBase<Contact>, IContactPersistenceService
    {
    }
}
