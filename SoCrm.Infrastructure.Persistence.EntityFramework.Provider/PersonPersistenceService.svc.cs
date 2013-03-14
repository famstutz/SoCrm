namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Customers.Contracts;

    public class PersonPersistenceService : PersistenceServiceBase<Person>, IPersonPersistenceService
    {
    }
}
