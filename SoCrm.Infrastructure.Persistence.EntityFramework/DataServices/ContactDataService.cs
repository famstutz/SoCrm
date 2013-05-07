// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The contact data service.
    /// </summary>
    public class ContactDataService : IDataService
    {
        /// <summary>
        /// The person data service.
        /// </summary>
        private IDataService personDataService;

        /// <summary>
        /// The user data service.
        /// </summary>
        private IDataService userDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactDataService"/> class.
        /// </summary>
        public ContactDataService()
        {
            this.userDataService = DataServiceFactory.Create(typeof(User));
            this.personDataService = DataServiceFactory.Create(typeof(Person));
        }

        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The object id.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public Guid Create(IDomainObject obj)
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

            return contact.ObjectId;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>The contacts.</returns>
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

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The contact.</returns>
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

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
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

        /// <summary>
        /// Deletes the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        public void Delete(Guid objectId)
        {
            using (var db = new ContactContext())
            {
                var contact = this.Read(objectId) as Contact;
                db.Contacts.Attach(contact);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }
    }
}