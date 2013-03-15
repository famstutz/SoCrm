// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAppController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The app controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App
{
    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The app controller.
    /// </summary>
    public interface IAppController : IController
    {
        /// <summary>
        /// Goes to user list.
        /// </summary>
        void GoToUserList();

        /// <summary>
        /// Goes to create user.
        /// </summary>
        void GoToCreateUser();
    }
}
