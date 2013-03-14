// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Contacts.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The contact service.
    /// </summary>
    [ServiceContract]
    public interface IContactService
    {
        /// <summary>
        /// Gets the contacts by person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The contacts.</returns>
        [OperationContract]
        IEnumerable<Contact> GetContactsByPerson(Person person);

        /// <summary>
        /// Gets the contacts by company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns>The contacts.</returns>
        [OperationContract]
        IEnumerable<Contact> GetContactsByCompany(Company company);

        /// <summary>
        /// Gets the contacts by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The contacts</returns>
        [OperationContract]
        IEnumerable<Contact> GetContactsByUser(User user);

        /// <summary>
        /// Gets the contact by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The contacts.</returns>
        [OperationContract]
        Contact GetContactByObjectId(Guid objectId);

        /// <summary>
        /// Gets the contacts by contact medium.
        /// </summary>
        /// <param name="contactMedium">The contact medium.</param>
        /// <returns>The contacts.</returns>
        [OperationContract]
        IEnumerable<Contact> GetContactsByContactMedium(ContactMedium contactMedium);

        /// <summary>
        /// Gets all contact mediums.
        /// </summary>
        /// <returns>The contact mediums.</returns>
        [OperationContract]
        IEnumerable<ContactMedium> GetAllContactMediums();

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="person">The person.</param>
        /// <param name="content">The content.</param>
        /// <param name="medium">The medium.</param>
        /// <param name="dateTime">The date time.</param>
        [OperationContract]
        void CreateContact(User user, Person person, string content, ContactMedium medium, DateTime dateTime);
    }
}
