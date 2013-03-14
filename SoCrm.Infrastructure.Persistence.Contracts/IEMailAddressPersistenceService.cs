// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEMailAddressPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The EMailAddressPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The EMailAddressPersistenceService interface.
    /// </summary>
    public interface IEMailAddressPersistenceService : IPersistenceService<EMailAddress>
    {
    }
}
