// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyPersistenceService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The CompanyPersistenceService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The CompanyPersistenceService.
    /// </summary>
    public class CompanyPersistenceService : PersistenceServiceBase<Company>, ICompanyPersistenceService
    {
    }
}
