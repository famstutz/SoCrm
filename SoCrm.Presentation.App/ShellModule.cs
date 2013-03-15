// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellModule.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The shell module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.App.Shell;
    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The shell module.
    /// </summary>
    public class ShellModule : IModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAppController, AppController>(new ContainerControlledLifetimeManager());
        }
    }
}
