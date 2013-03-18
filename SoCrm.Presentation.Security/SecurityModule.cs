// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityModule.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Presentation.Security.CreateUser;
    using SoCrm.Presentation.Security.Security;
    using SoCrm.Presentation.Security.SetPassword;
    using SoCrm.Presentation.Security.UserList;

    /// <summary>
    /// The security module.
    /// </summary>
    public class SecurityModule : IModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ISecurityController, SecurityController>();

            container.RegisterType<IAuthenticationService, AuthenticationService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IUserListViewModel, UserListViewModel>();
            container.RegisterType<ICreateUserViewModel, CreateUserViewModel>();
            container.RegisterType<ISetPasswordViewModel, SetPasswordViewModel>();
            container.RegisterType<IAuthenticationViewModel, AuthenticationViewModel>();

            container.RegisterInstance(typeof(ISecurityService), new SecurityServiceClient(), new ContainerControlledLifetimeManager());
        }
    }
}
