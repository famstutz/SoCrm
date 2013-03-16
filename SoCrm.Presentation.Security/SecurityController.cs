// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Security.CreateUser;
    using SoCrm.Presentation.Security.SetPassword;
    using SoCrm.Presentation.Security.UserList;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The security controller.
    /// </summary>
    public class SecurityController : ISecurityController
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// The main region.
        /// </summary>
        private readonly IRegion mainRegion;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="mainRegion">The main region.</param>
        public SecurityController(IUnityContainer container, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
        {
            this.container = container;
            this.mainRegion = mainRegion;
        }

        /// <summary>
        /// Navigates to user list.
        /// </summary>
        public void NavigateToUserList()
        {
            var userListViewModel = this.container.Resolve<IUserListViewModel>();
            this.mainRegion.Context = userListViewModel;
        }

        /// <summary>
        /// Navigates to create user.
        /// </summary>
        public void NavigateToCreateUser()
        {
            var createUserListViewModel = this.container.Resolve<ICreateUserViewModel>();
            this.mainRegion.Context = createUserListViewModel;
        }

        /// <summary>
        /// Navigates to set password.
        /// </summary>
        /// <param name="user">The user.</param>
        public void NavigateToSetPassword(User user)
        {
            var setPasswordViewModel = this.container.Resolve<ISetPasswordViewModel>(new ParameterOverride("user", user));
            this.mainRegion.Context = setPasswordViewModel;
        }
    }
}
