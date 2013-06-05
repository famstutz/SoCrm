// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEvent.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The log event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Logging.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The log event.
    /// </summary>
    [DataContract]
    public class LogEvent : DomainObject
    {
        /// <summary>
        /// The message.
        /// </summary>
        private string message;

        /// <summary>
        /// The severity.
        /// </summary>
        private Severity severity;

        /// <summary>
        /// The time stamp.
        /// </summary>
        private DateTime timeStamp;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember]
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        /// <value>
        /// The severity.
        /// </value>
        [DataMember]
        public Severity Severity
        {
            get
            {
                return this.severity;
            }

            set
            {
                this.severity = value;
            }
        }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        [DataMember]
        public DateTime TimeStamp
        {
            get
            {
                return this.timeStamp;
            }

            set
            {
                this.timeStamp = value;
            }
        }
    }
}
