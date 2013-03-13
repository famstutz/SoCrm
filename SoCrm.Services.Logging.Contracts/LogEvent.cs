﻿namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using SoCrm.Contracts;
    
    [DataContract]
    public class LogEvent : DomainObject
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Severity Severity { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
