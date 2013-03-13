namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using System;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;
    using SoCrm.Services.Logging.Contracts;

    public static class DataServiceFactory
    {
        public static IDataService Create(Type type)
        {
            if (type == typeof(LogEvent))
            {
                return new LogEventDataService();
            }
            throw new NotSupportedException(string.Format("Type <{0}> is not supported.", type));
        }
    }
}