namespace SoCrm.Services.Contacts.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using SoCrm.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    [DataContract]
    public class Contact : DomainObject
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public Guid PersonId { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public ContactMedium Medium { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public Person Person { get; set; }
    }
}
