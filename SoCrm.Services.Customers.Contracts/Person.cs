namespace SoCrm.Services.Customers.Contracts
{
    using System.Collections.Generic;

    using SoCrm.Contracts;

    public class Person : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Employer { get; set; }
        public Address Address { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public IEnumerable<EMailAddress> EMailAddresses { get; set; }
    }
}
