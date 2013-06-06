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
    public abstract class ControllerBase : IController
    {
        /// <summary>
        /// The main region.
        /// </summary>
        protected readonly IRegion MainRegion;

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// The status bar service.
        /// </summary>
        private readonly IStatusBarService statusBarService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase" /> class.
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="mainRegion">The main region.</param>
        public ControllerBase(IUnityContainer unityContainer, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
        {
            this.container = unityContainer;
            this.statusBarService = this.container.Resolve<IStatusBarService>();
            this.MainRegion = mainRegion;
        }

        /// <summary>
        /// Sets the last status.
        /// </summary>
        /// <param name="status">The status.</param>
        public void SetLastStatus(string status)
        {
            this.statusBarService.LastStatus = status;
        }

        /// <summary>
        /// Clears the main region.
        /// </summary>
        public void ClearMainRegion()
        {
            this.MainRegion.Context = null;
        }
    }
}
