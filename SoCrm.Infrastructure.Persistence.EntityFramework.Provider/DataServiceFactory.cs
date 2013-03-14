// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataServiceFactory.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The data service factory returns a data service for the given type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using System;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The data service factory returns a data service for the given type.
    /// </summary>
    public static class DataServiceFactory
    {
        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A data service.</returns>
        /// <exception cref="System.NotSupportedException">In case the given type is not supported.</exception>
        public static IDataService Create(Type type)
        {
            if (type == typeof(LogEvent))
            {
                return new LogEventDataService();
            }

            if (type == typeof(PhoneNumber))
            {
                return new PhoneNumberDataService();
            }

            if (type == typeof(Address))
            {
                return new AddressDataService();
            }

            if (type == typeof(EMailAddress))
            {
                return new EMailAddressDataService();
            }

            if (type == typeof(Company))
            {
                return new CompanyDataService();
            }

            if (type == typeof(Person))
            {
                return new PersonDataService();
            }

            if (type == typeof(User))
            {
                return new UserDataService();
            }

            if (type == typeof(Contact))
            {
                return new ContactDataService();
            }

            throw new NotSupportedException(string.Format("Type <{0}> is not supported.", type));
        }
    }
}