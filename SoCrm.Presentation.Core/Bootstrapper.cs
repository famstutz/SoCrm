// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core
{
    using System;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The bootstrapper.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public Bootstrapper(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        /// <returns>The bootstrapper.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the module type is null.</exception>
        public Bootstrapper RegisterModule(Type moduleType)
        {
            var module = this.container.Resolve(moduleType) as IModule;
            if (module == null)
            {
                throw new ArgumentException("moduleType");
            }

            module.Register(this.container);
            return this;
        }
    }
}
