using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoCrm.Services.Customers.Contracts
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IEnumerable<Person> GetAllPersons();

        [OperationContract]
        IEnumerable<Company> GetAllCompanies();

        [OperationContract]
        IEnumerable<Address> GetAllAddresses();
        
        [OperationContract]
        IEnumerable<EMailAddress> GetAllEMailAddresses();

        [OperationContract]
        IEnumerable<PhoneNumber> GetAllPhoneNumbers();

        [OperationContract]
        Person GetPersonByObjectId(Guid objectId);

        [OperationContract]
        Company GetCompanyByObjectId(Guid objectId);

        [OperationContract]
        void CreateAddress(string addressLine, string zipCode, string city, string country);
        
        [OperationContract]
        void CreatePhoneNumber(string phoneNumber, ContactType contactType);
        
        [OperationContract]
        void CreateEmailAddress(string eMailAddress, ContactType contactType);

        [OperationContract]
        void CreateCompany(string name, Address address, string website);

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
