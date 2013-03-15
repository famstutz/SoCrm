// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegion.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The region.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    /// The region.
    /// </summary>
    public interface IRegion : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        IViewModelBase Context { get; set; }
    }
}