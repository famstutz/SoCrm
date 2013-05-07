// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The AddressPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The AddressPersistenceService.
    /// </summary>
    public class AddressPersistenceService : PersistenceServiceBase<Address>, IAddressPersistenceService
    {
    }
}
