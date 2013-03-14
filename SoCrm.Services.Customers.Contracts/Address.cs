namespace SoCrm.Services.Customers.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Contracts;

    [DataContract]
    public class Address : DomainObject
    {
        [DataMember]
        public string AddressLine { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}
