// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core.Interfaces
{
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The module.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        void Register(IUnityContainer container);
    }
}
