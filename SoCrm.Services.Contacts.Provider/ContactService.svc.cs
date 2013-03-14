namespace SoCrm.Services.Contacts.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    public class ContactService : IContactService
    {
        private ContactPersistence.PersistenceServiceOf_ContactClient client;

        public ContactService()
        {
            this.client = new ContactPersistence.PersistenceServiceOf_ContactClient();
        }

        public IEnumerable<Contact> GetContactsByPerson(Person person)
        {
            return this.client.GetAll().Where(c => c.Person == person);
        }

        public IEnumerable<Contact> GetContactsByCompany(Company company)
        {
            return this.client.GetAll().Where(c => c.Person.Employer == company);
        }

        public IEnumerable<Contact> GetContactsByUser(User user)
        {
            return this.client.GetAll().Where(c => c.User == user);
        }

        public Contact GetContactByObjectId(Guid objectId)
        {
            return this.client.Get(objectId);
        }

        public IEnumerable<Contact> GetContactsByContactMedium(ContactMedium contactMedium)
        {
            return this.client.GetAll().Where(c => c.Medium == contactMedium);
        }

        public IEnumerable<ContactMedium> GetAllContactMediums()
        {
            return Enum.GetValues(typeof(ContactMedium)).Cast<ContactMedium>();
        }

        public void CreateContact(User user, Person person, string content, ContactMedium medium, DateTime dateTime)
        {
            this.client.Save(
                new Contact() { Content = content, DateTime = dateTime, Medium = medium, Person = person, User = user });
        }
    }
}
