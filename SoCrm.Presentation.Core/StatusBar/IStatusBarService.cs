// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatusBarService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The status bar service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core.StatusBar
{
    using System;

    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The status bar service.
    /// </summary>
    public interface IStatusBarService : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the last status.
        /// </summary>
        /// <value>
        /// The last status.
        /// </value>
        string LastStatus { get; set; }
    }
}
