using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SoCrm.Services.Customers.Provider
{
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Customers.Provider.AddressPersistence;
    using SoCrm.Services.Customers.Provider.CompanyPersistence;
    using SoCrm.Services.Customers.Provider.EMailAddressPersistence;
    using SoCrm.Services.Customers.Provider.PersonPersistence;
    using SoCrm.Services.Customers.Provider.PhoneNumberPersistence;

    public sealed class CustomerService : ICustomerService, IDisposable
    {
        private PersistenceServiceOf_AddressClient addressClient;
        private PersistenceServiceOf_CompanyClient companyClient;
        private PersistenceServiceOf_EMailAddressClient eMailAddressClient;
        private PersistenceServiceOf_PersonClient personClient;
        private PersistenceServiceOf_PhoneNumberClient phoneNumberClient;

        public CustomerService()
        {
            this.addressClient = new PersistenceServiceOf_AddressClient();
            this.companyClient = new PersistenceServiceOf_CompanyClient();
            this.eMailAddressClient = new PersistenceServiceOf_EMailAddressClient();
            this.personClient = new PersistenceServiceOf_PersonClient();
            this.phoneNumberClient = new PersistenceServiceOf_PhoneNumberClient();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return this.personClient.GetAll();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return this.companyClient.GetAll();
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return this.addressClient.GetAll();
        }

        public IEnumerable<EMailAddress> GetAllEMailAddresses()
        {
            return this.eMailAddressClient.GetAll();
        }

        public IEnumerable<PhoneNumber> GetAllPhoneNumbers()
        {
            return this.phoneNumberClient.GetAll();
        }

        public Person GetPersonByObjectId(Guid objectId)
        {
            return this.personClient.Get(objectId);
        }

        public Company GetCompanyByObjectId(Guid objectId)
        {
            return this.companyClient.Get(objectId);
        }

        public void CreateAddress(string addressLine, string zipCode, string city, string country)
        {
            this.addressClient.Save(
                new Address() { AddressLine = addressLine, City = city, Country = country, ZipCode = zipCode });
        }

        public void CreatePhoneNumber(string phoneNumber, ContactType contactType)
        {
            this.phoneNumberClient.Save(new PhoneNumber() { ContactType = contactType, Number = phoneNumber });
        }

        public void CreateEmailAddress(string eMailAddress, ContactType contactType)
        {
            this.eMailAddressClient.Save(new EMailAddress() { Address = eMailAddress, ContactType = contactType });
        }

        public void CreateCompany(string name, Address address, string website)
        {
            this.companyClient.Save(new Company() { Address = address, Website = website, Name = name });
        }

        public void CreatePerson(
            string firstName,
            string lastName,
            Company employer,
            Address address,
            IEnumerable<PhoneNumber> phoneNumbers,
            IEnumerable<EMailAddress> emailAddresses)
        {
            this.personClient.Save(
                new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Employer = employer,
                        Address = address,
                        PhoneNumbers = phoneNumbers,
                        EMailAddresses = emailAddresses
                    });
        }

        public void Dispose()
        {
            this.addressClient.Close();
            this.companyClient.Close();
            this.eMailAddressClient.Close();
            this.personClient.Close();
            this.phoneNumberClient.Close();
        }
    }
}
