// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EMailAddressPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The EMailAddressPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The EMailAddressPersistenceService.
    /// </summary>
    public class EMailAddressPersistenceService : PersistenceServiceBase<EMailAddress>, IEMailAddressPersistenceService
    {
    }
}
