// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The region model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core
{
    using System.ComponentModel;

    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The region model.
    /// </summary>
    public class RegionModel : IRegion
    {
        /// <summary>
        /// The context.
        /// </summary>
        private IViewModelBase context;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public IViewModelBase Context
        {
            get
            {
                return this.context;
            }

            set
            {
                this.context = value;
                this.InvokePropertyChanged("Context");
            }
        }

        /// <summary>
        /// Invokes the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void InvokePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
