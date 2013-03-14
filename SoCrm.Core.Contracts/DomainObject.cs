// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainObject.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The domain object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// The domain object.
    /// </summary>
    [DataContract]
    public class DomainObject : IDomainObject
    {
        /// <summary>
        /// Gets or sets the object id.
        /// </summary>
        [DataMember]
        [Key]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the creation time stamp.
        /// </summary>
        [DataMember]
        public DateTime CreationTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the last update time stamp.
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTimeStamp { get; set; }
    }
}
