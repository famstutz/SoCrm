namespace SoCrm.Services.Security.Contracts
{
    using System.Runtime.Serialization;

    using SoCrm.Contracts;

    [DataContract]
    public class User : DomainObject
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public Role Role { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
