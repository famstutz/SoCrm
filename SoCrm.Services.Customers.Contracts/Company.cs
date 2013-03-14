namespace SoCrm.Services.Customers.Contracts
{
    using System.Collections.Generic;

    using SoCrm.Contracts;

    public class Company : DomainObject
    {
        public string Name { get; set; }
        public IEnumerable<Person> Employees { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
    }
}
