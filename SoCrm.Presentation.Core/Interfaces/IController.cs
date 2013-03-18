// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core.Interfaces
{
    /// <summary>
    /// The controller.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Sets the last status.
        /// </summary>
        /// <param name="status">The status.</param>
        void SetLastStatus(string status);

        /// <summary>
        /// Clears the main region.
        /// </summary>
        void ClearMainRegion();
    }
}
