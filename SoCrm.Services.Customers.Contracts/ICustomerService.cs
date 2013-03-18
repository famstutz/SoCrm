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
        /// Gets all countries.
        /// </summary>
        /// <returns>All countries.</returns>
        [OperationContract]
        IEnumerable<string> GetAllCountries();

            /// <summary>
        /// Gets all email addresses.
        /// </summary>
        /// <returns>All email addresses.</returns>
        [OperationContract]
        IEnumerable<EMailAddress> GetAllEMailAddresses();

        /// <summary>
        /// Gets the contact types.
        /// </summary>
        /// <returns>The contact types.</returns>
        [OperationContract]
        IEnumerable<ContactType> GetContactTypes();

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
        /// Gets the companies by name and country.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="counrty">The country.</param>
        /// <returns>The companies.</returns>
        [OperationContract]
        IEnumerable<Company> GetCompaniesByNameAndCountry(string name, string counrty);

        /// <summary>
        /// Gets the company by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The company.</returns>
        [OperationContract]
        Company GetCompanyByObjectId(Guid objectId);

        /// <summary>
        /// Creates the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="contactType">Type of the contact.</param>
        /// <returns>The created phone number.</returns>
        [OperationContract]
        PhoneNumber CreatePhoneNumber(string phoneNumber, ContactType contactType);

        /// <summary>
        /// Creates the email address.
        /// </summary>
        /// <param name="emailAddress">The e mail address.</param>
        /// <param name="contactType">Type of the contact.</param>
        /// <returns>The created e mail address.</returns>
        [OperationContract]
        EMailAddress CreateEmailAddress(string emailAddress, ContactType contactType);

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="addressLine">The address line.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        /// <param name="website">The website.</param>
        /// <returns>The created company.</returns>
        [OperationContract]
        Company CreateCompany(string name, string addressLine, string zipCode, string city, string country, string website);

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="employer">The employer.</param>
        /// <param name="addressLine">The address line.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <param name="emailAddresses">The email addresses.</param>
        /// <returns>The created person.</returns>
        [OperationContract]
        Person CreatePerson(
            string firstName,
            string lastName,
            Company employer,
            string addressLine,
            string zipCode,
            string city,
            string country,
            ICollection<PhoneNumber> phoneNumbers,
            ICollection<EMailAddress> emailAddresses);

        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="person">The person.</param>
        [OperationContract]
        void DeletePerson(Person person);

        /// <summary>
        /// Deletes the E mail address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        [OperationContract]
        void DeleteEMailAddress(EMailAddress emailAddress);

        /// <summary>
        /// Deletes the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        [OperationContract]
        void DeletePhoneNumber(PhoneNumber phoneNumber);
    }
}
