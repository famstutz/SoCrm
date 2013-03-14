namespace SoCrm.Services.Customers.Contracts
{
    using SoCrm.Contracts;

    public class Address : DomainObject
    {
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
