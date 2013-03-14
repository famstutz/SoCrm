// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddressPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The AddressPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The AddressPersistenceService interface.
    /// </summary>
    public interface IAddressPersistenceService : IPersistenceService<Address>
    {
    }
}
