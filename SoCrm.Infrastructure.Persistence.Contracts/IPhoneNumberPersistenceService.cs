// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPhoneNumberPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The PhoneNumberPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The PhoneNumberPersistenceService interface.
    /// </summary>
    public interface IPhoneNumberPersistenceService : IPersistenceService<PhoneNumber>
    {
    }
}
