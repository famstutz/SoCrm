namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using System;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Services.Security.Contracts;

    public static class DataServiceFactory
    {
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