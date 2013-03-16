// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    /// <summary>
    /// The customer service.
    /// </summary>
    [ServiceContract]
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns>All persons.</returns>
        [OperationContract]
        IEnumerable<Person> GetAllPersons();

        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <returns>All companies.</returns>
        [OperationContract]
        IEnumerable<Company> GetAllCompanies();

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>All addresses.</returns>
        [OperationContract]
        IEnumerable<Address> GetAllAddresses();

        /// <summary>
        /// Gets all email addresses.
        /// </summary>
        /// <returns>All email addresses.</returns>
        [OperationContract]
        IEnumerable<EMailAddress> GetAllEMailAddresses();

        /// <summary>
        /// Gets all phone numbers.
        /// </summary>
        /// <returns>All phone numbers.</returns>
        [OperationContract]
        IEnumerable<PhoneNumber> GetAllPhoneNumbers();

        /// <summary>
        /// Gets the person by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The person.</returns>
        [OperationContract]
        Person GetPersonByObjectId(Guid objectId);

        /// <summary>
        /// Gets the persons by name and company.
        /// </summary>
        /// <param name="personName">Name of the person.</param>
        /// <param name="companyName">Name of the company.</param>
        /// <returns>The persons.</returns>
        [OperationContract]
        IEnumerable<Person> GetPersonsByNameAndCompany(string personName, string companyName);

            /// <summary>
        /// Gets the company by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The company.</returns>
        [OperationContract]
        Company GetCompanyByObjectId(Guid objectId);

        /// <summary>
        /// Creates the address.
        /// </summary>
        /// <param name="addressLine">The address line.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        [OperationContract]
        void CreateAddress(string addressLine, string zipCode, string city, string country);

        /// <summary>
        /// Creates the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="contactType">Type of the contact.</param>
        [OperationContract]
        void CreatePhoneNumber(string phoneNumber, ContactType contactType);

        /// <summary>
        /// Creates the email address.
        /// </summary>
        /// <param name="emailAddress">The e mail address.</param>
        /// <param name="contactType">Type of the contact.</param>
        [OperationContract]
        void CreateEmailAddress(string emailAddress, ContactType contactType);

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="website">The website.</param>
        [OperationContract]
        void CreateCompany(string name, Address address, string website);

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="employer">The employer.</param>
        /// <param name="address">The address.</param>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <param name="emailAddresses">The email addresses.</param>
        [OperationContract]
        void CreatePerson(
            string firstName,
            string lastName,
            Company employer,
            Address address,
            IEnumerable<PhoneNumber> phoneNumbers,
            IEnumerable<EMailAddress> emailAddresses);
    }
}
