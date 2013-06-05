// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainObject.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The domain object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Core.Contracts
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
        /// The last update time stamp.
        /// </summary>
        private DateTime lastUpdateTimeStamp;

        /// <summary>
        /// The creation time stamp.
        /// </summary>
        private DateTime creationTimeStamp;

        /// <summary>
        /// The object id.
        /// </summary>
        private Guid objectId;

        /// <summary>
        /// Gets or sets the object id.
        /// </summary>
        [DataMember]
        [Key]
        public Guid ObjectId
        {
            get
            {
                return this.objectId;
            }

            set
            {
                this.objectId = value;
            }
        }

        /// <summary>
        /// Gets or sets the creation time stamp.
        /// </summary>
        [DataMember]
        public DateTime CreationTimeStamp
        {
            get
            {
                return this.creationTimeStamp;
            }

            set
            {
                this.creationTimeStamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the last update time stamp.
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTimeStamp
        {
            get
            {
                return this.lastUpdateTimeStamp;
            }

            set
            {
                this.lastUpdateTimeStamp = value;
            }
        }
    }
}
