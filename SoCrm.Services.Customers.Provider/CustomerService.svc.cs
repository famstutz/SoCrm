// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerService.svc.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Customers.Provider.AddressPersistence;
    using SoCrm.Services.Customers.Provider.CompanyPersistence;
    using SoCrm.Services.Customers.Provider.EMailAddressPersistence;
    using SoCrm.Services.Customers.Provider.PersonPersistence;
    using SoCrm.Services.Customers.Provider.PhoneNumberPersistence;

    /// <summary>
    /// The customer service.
    /// </summary>
    public sealed class CustomerService : ICustomerService, IDisposable
    {
        /// <summary>
        /// The address client.
        /// </summary>
        private readonly PersistenceServiceOf_AddressClient addressClient;

        /// <summary>
        /// The company client.
        /// </summary>
        private readonly PersistenceServiceOf_CompanyClient companyClient;

        /// <summary>
        /// The e mail address client.
        /// </summary>
        private readonly PersistenceServiceOf_EMailAddressClient emailAddressClient;

        /// <summary>
        /// The person client.
        /// </summary>
        private readonly PersistenceServiceOf_PersonClient personClient;

        /// <summary>
        /// The phone number client
        /// </summary>
        private readonly PersistenceServiceOf_PhoneNumberClient phoneNumberClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        public CustomerService()
        {
            this.addressClient = new PersistenceServiceOf_AddressClient();
            this.companyClient = new PersistenceServiceOf_CompanyClient();
            this.emailAddressClient = new PersistenceServiceOf_EMailAddressClient();
            this.personClient = new PersistenceServiceOf_PersonClient();
            this.phoneNumberClient = new PersistenceServiceOf_PhoneNumberClient();
        }

        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns>
        /// All persons.
        /// </returns>
        public IEnumerable<Person> GetAllPersons()
        {
            return this.personClient.GetAll();
        }

        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <returns>
        /// All companies.
        /// </returns>
        public IEnumerable<Company> GetAllCompanies()
        {
            return this.companyClient.GetAll();
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>
        /// All addresses.
        /// </returns>
        public IEnumerable<Address> GetAllAddresses()
        {
            return this.addressClient.GetAll();
        }

        /// <summary>
        /// Gets all email addresses.
        /// </summary>
        /// <returns>
        /// All email addresses.
        /// </returns>
        public IEnumerable<EMailAddress> GetAllEMailAddresses()
        {
            return this.emailAddressClient.GetAll();
        }

        /// <summary>
        /// Gets all phone numbers.
        /// </summary>
        /// <returns>
        /// All phone numbers.
        /// </returns>
        public IEnumerable<PhoneNumber> GetAllPhoneNumbers()
        {
            return this.phoneNumberClient.GetAll();
        }

        /// <summary>
        /// Gets the person by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The person.
        /// </returns>
        public Person GetPersonByObjectId(Guid objectId)
        {
            return this.personClient.Get(objectId);
        }

        /// <summary>
        /// Gets the persons by name and company.
        /// </summary>
        /// <param name="personName">Name of the person.</param>
        /// <param name="companyName">Name of the company.</param>
        /// <returns>
        /// The persons.
        /// </returns>
        public IEnumerable<Person> GetPersonsByNameAndCompany(string personName, string companyName)
        {
            var persons = this.GetAllPersons();

            if (!string.IsNullOrWhiteSpace(personName))
            {
                persons = persons.Where(p => p.FirstName.Contains(personName) || p.LastName.Contains(personName));
            }

            if (!string.IsNullOrWhiteSpace(companyName))
            {
                persons = persons.Where(p => p.Employer != null && p.Employer.Name.Contains(companyName));
            }

            return persons;
        }

        /// <summary>
        /// Gets the company by object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The company.
        /// </returns>
        public Company GetCompanyByObjectId(Guid objectId)
        {
            return this.companyClient.Get(objectId);
        }

        /// <summary>
        /// Creates the address.
        /// </summary>
        /// <param name="addressLine">The address line.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        public void CreateAddress(string addressLine, string zipCode, string city, string country)
        {
            this.addressClient.Save(
                new Address { AddressLine = addressLine, City = city, Country = country, ZipCode = zipCode });
        }

        /// <summary>
        /// Creates the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="contactType">Type of the contact.</param>
        public void CreatePhoneNumber(string phoneNumber, ContactType contactType)
        {
            this.phoneNumberClient.Save(new PhoneNumber { ContactType = contactType, Number = phoneNumber });
        }

        /// <summary>
        /// Creates the email address.
        /// </summary>
        /// <param name="emailAddress">The e mail address.</param>
        /// <param name="contactType">Type of the contact.</param>
        public void CreateEmailAddress(string emailAddress, ContactType contactType)
        {
            this.emailAddressClient.Save(new EMailAddress { Address = emailAddress, ContactType = contactType });
        }

        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="website">The website.</param>
        public void CreateCompany(string name, Address address, string website)
        {
            this.companyClient.Save(new Company { Address = address, Website = website, Name = name });
        }

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="employer">The employer.</param>
        /// <param name="address">The address.</param>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <param name="emailAddresses">The email addresses.</param>
        public void CreatePerson(
            string firstName,
            string lastName,
            Company employer,
            Address address,
            IEnumerable<PhoneNumber> phoneNumbers,
            IEnumerable<EMailAddress> emailAddresses)
        {
            this.personClient.Save(
                new Person
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Employer = employer,
                        Address = address,
                        PhoneNumbers = phoneNumbers,
                        EMailAddresses = emailAddresses
                    });
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.addressClient.Close();
            this.companyClient.Close();
            this.emailAddressClient.Close();
            this.personClient.Close();
            this.phoneNumberClient.Close();
        }
    }
}
