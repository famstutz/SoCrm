// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainObject.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The domain object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Core.Contracts
{
    using System;

    /// <summary>
    /// The domain object.
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Gets or sets the object id.
        /// </summary>
        /// <value>
        /// The object id.
        /// </value>
        Guid ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the creation time stamp.
        /// </summary>
        /// <value>
        /// The creation time stamp.
        /// </value>
        DateTime CreationTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the last update time stamp.
        /// </summary>
        /// <value>
        /// The last update time stamp.
        /// </value>
        DateTime LastUpdateTimeStamp { get; set; }
    }
}
