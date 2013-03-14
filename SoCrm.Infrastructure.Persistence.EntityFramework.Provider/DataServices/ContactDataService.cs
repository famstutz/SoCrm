using System;
using System.Collections.Generic;
using System.Linq;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    public class ContactDataService : IDataService
    {
        private IDataService personDataService;

        private IDataService userDataService;

        public ContactDataService()
        {
            this.userDataService = DataServiceFactory.Create(typeof(User));
            this.personDataService = DataServiceFactory.Create(typeof(Person));
        }

        public void Create(IDomainObject obj)
        {
            var contact = obj as Contact;
            if (contact == null)
            {
                throw new NotSupportedException(string.Format("ContactDataService cannot deal with supplied type"));
            }

            if (contact.ObjectId == default(Guid))
            {
                contact.ObjectId = Guid.NewGuid();
            }

            contact.CreationTimeStamp = DateTime.Now;
            contact.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new ContactContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new ContactContext())
            {
                var contacts = db.Contacts.ToList();
                foreach (var contact in contacts)
                {
                    contact.Person = (Person)this.personDataService.Read(contact.PersonId);
                    contact.User = (User)this.userDataService.Read(contact.UserId);
                }
                return contacts;
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new ContactContext())
            {
                var contact = db.Contacts.Single(c => c.ObjectId.Equals(objectId));
                contact.Person = (Person)this.personDataService.Read(contact.PersonId);
                contact.User = (User)this.userDataService.Read(contact.UserId);
                return contact;
            }
        }

        public void Update(IDomainObject obj)
        {
            var contact = obj as Contact;
            if (contact == null)
            {
                throw new NotSupportedException(string.Format("ContactDataService cannot deal with supplied type"));
            }

            using (var db = new ContactContext())
            {
                var readContact = db.Contacts.Single(c => c.ObjectId.Equals(contact.ObjectId));
                readContact.Content = contact.Content;
                readContact.DateTime = contact.DateTime;
                readContact.Medium = contact.Medium;
                readContact.PersonId = contact.Person.ObjectId;
                readContact.UserId = contact.User.ObjectId;
                readContact.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(Guid objectId)
        {
            using (var db = new ContactContext())
            {
                db.Contacts.Remove(this.Read(objectId) as Contact);
                db.SaveChanges();
            }
        }
    }
}