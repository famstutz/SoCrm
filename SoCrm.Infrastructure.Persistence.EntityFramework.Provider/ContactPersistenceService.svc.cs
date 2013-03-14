namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Services.Contacts.Contracts;

    public class ContactPersistenceService : PersistenceServiceBase<Contact>, IContactPersistenceService
    {
    }
}
