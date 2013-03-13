namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using SoCrm.Contracts;
    
    [DataContract]
    public class LogEvent : ObjectBase
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Severity Serverity { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
