// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The view model base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SoCrm.Presentation.App.Annotations;

    /// <summary>
    /// The view model base class.
    /// </summary>
    public abstract class ViewModelBase : IViewModelBase
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}