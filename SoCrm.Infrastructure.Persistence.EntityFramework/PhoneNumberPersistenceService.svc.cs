// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The PhoneNumberPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The PhoneNumberPersistenceService.
    /// </summary>
    public class PhoneNumberPersistenceService : PersistenceServiceBase<PhoneNumber>, IPhoneNumberPersistenceService
    {
    }
}
