namespace SoCrm.Services.Contacts.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        IEnumerable<Contact> GetContactsByPerson(Person person);

        [OperationContract]
        IEnumerable<Contact> GetContactsByCompany(Company company);

        [OperationContract]
        IEnumerable<Contact> GetContactsByUser(User user);

        [OperationContract]
        Contact GetContactByObjectId(Guid objectId);

        [OperationContract]
        IEnumerable<Contact> GetContactsByContactMedium(ContactMedium contactMedium);

        [OperationContract]
        IEnumerable<ContactMedium> GetAllContactMediums();

        [OperationContract]
        void CreateContact(User user, Person person, string content, ContactMedium medium, DateTime dateTime);
    }
}
