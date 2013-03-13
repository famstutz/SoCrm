namespace SoCrm.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class ObjectBase : IDomainObject
    {
        [DataMember]
        [Key]
        public Guid ObjectId { get; set; }

        [DataMember]
        public DateTime CreationTimeStamp { get; set; }

        [DataMember]
        public DateTime LastUpdateTimeStamp { get; set; }
    }
}
