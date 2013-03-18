﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactModule.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Contacts.Contact;
    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The contact module.
    /// </summary>
    public class ContactModule : IModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IContactController, ContactController>();

            container.RegisterInstance(typeof(IContactService), new ContactServiceClient(), new ContainerControlledLifetimeManager());
        }
    }
}