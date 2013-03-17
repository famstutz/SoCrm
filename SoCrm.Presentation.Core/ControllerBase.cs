// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerBase.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The controller base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;

    /// <summary>
    /// The controller base.
    /// </summary>
    public class ControllerBase : IController
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// The status bar service.
        /// </summary>
        private readonly IStatusBarService statusBarService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase"/> class.
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        public ControllerBase(IUnityContainer unityContainer)
        {
            this.container = unityContainer;
            this.statusBarService = this.container.Resolve<IStatusBarService>();
        }

        /// <summary>
        /// Sets the last status.
        /// </summary>
        /// <param name="status">The status.</param>
        public void SetLastStatus(string status)
        {
            this.statusBarService.LastStatus = status;
        }
    }
}
