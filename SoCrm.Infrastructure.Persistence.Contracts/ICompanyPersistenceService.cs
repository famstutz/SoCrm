// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompanyPersistenceService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The CompanyPersistenceService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The CompanyPersistenceService interface.
    /// </summary>
    public interface ICompanyPersistenceService : IPersistenceService<Company>
    {
    }
}
