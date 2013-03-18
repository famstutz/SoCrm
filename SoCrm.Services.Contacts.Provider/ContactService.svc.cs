// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Contacts.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The contact service.
    /// </summary>
    public sealed class ContactService : IContactService, IDisposable
    {
        /// <summary>
        /// The contact client.
        /// </summary>
        private ContactPersistence.PersistenceServiceOf_ContactClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        public ContactService()
        {
            this.client = new ContactPersistence.PersistenceServiceOf_ContactClient();
        }

        /// <summary>
        /// Gets the contacts by person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>
        /// The contacts.
        /// </returns>
        public IEnumerable<Contact> GetContactsByPerson(Person person)
        {
            return this.client.GetAll().Where(c => c.Person == person);
        }

        /// <summary>
        /// Gets the contacts by company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns>
        /// The contacts.
        /// </returns>
        public IEnumerable<Contact> GetContactsByCompany(Company company)
        {
            return this.client.GetAll().Where(c => c.Person.Employer == company);
        }

        /// <summary>
        /// Gets the contacts by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The contacts
        /// </returns>
        public IEnumerable<Contact> GetContactsByUser(User user)
        {
            return this.client.GetAll().Where(c => c.User == user);
        }

        /// <summary>
        /// Gets the contact by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The contacts.
        /// </returns>
        public Contact GetContactByObjectId(Guid objectId)
        {
            return this.client.Get(objectId);
        }

        /// <summary>
        /// Gets the contacts by contact medium.
        /// </summary>
        /// <param name="contactMedium">The contact medium.</param>
        /// <returns>
        /// The contacts.
        /// </returns>
        public IEnumerable<Contact> GetContactsByContactMedium(ContactMedium contactMedium)
        {
            return this.client.GetAll().Where(c => c.Medium == contactMedium);
        }

        /// <summary>
        /// Gets the contacts by contact medium and person.
        /// </summary>
        /// <param name="contactMedium">The contact medium.</param>
        /// <param name="personName">The person name.</param>
        /// <returns>
        /// The contacts.
        /// </returns>
        public IEnumerable<Contact> GetContactsByContactMediumAndPersonName(ContactMedium contactMedium, string personName)
        {
            var contacts = this.GetContactsByContactMedium(contactMedium);

            if (!string.IsNullOrWhiteSpace(personName))
            {
                contacts =
                    contacts.Where(
                        c =>
                        c.Person != null
                        & (c.Person.FirstName.Contains(personName) || c.Person.LastName.Contains(personName)));
            }

            return contacts;
        }

        /// <summary>
        /// Gets all contact mediums.
        /// </summary>
        /// <returns>
        /// The contact mediums.
        /// </returns>
        public IEnumerable<ContactMedium> GetAllContactMediums()
        {
            return Enum.GetValues(typeof(ContactMedium)).Cast<ContactMedium>();
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="person">The person.</param>
        /// <param name="content">The content.</param>
        /// <param name="medium">The medium.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        /// The created contact.
        /// </returns>
        public Contact CreateContact(User user, Person person, string content, ContactMedium medium, DateTime dateTime)
        {
            var contactObjectId =
                this.client.Save(
                    new Contact
                        {
                            Content = content,
                            DateTime = dateTime,
                            Medium = medium,
                            Person = person,
                            User = user,
                            PersonId = person.ObjectId,
                            UserId = user.ObjectId
                        });
            return this.GetContactByObjectId(contactObjectId);
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void DeleteContact(Contact contact)
        {
            this.client.Remove(contact);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.client.Close();
        }
    }
}
