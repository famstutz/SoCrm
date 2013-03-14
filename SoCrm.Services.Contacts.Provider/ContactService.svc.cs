namespace SoCrm.Services.Contacts.Provider
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Services.Contacts.Contracts;

    public class ContactService : IContactService
    {
        public IEnumerable<Contact> GetContactsByPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsByCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByObjectId(Guid objectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsByContactMedium(ContactMedium contactMedium)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactMedium> GetAllContactMediums()
        {
            throw new NotImplementedException();
        }

        public void CreateContact(User user, Person person, string content, ContactMedium medium, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
