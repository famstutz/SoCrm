// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactServiceHostFactory.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact service host factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Services.Contacts.Provider
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    using Microsoft.Practices.Unity;

    using SoCrm.Core.Services;
    using SoCrm.Services.Contacts.Provider.ContactPersistence;

    /// <summary>
    /// The contact service host factory.
    /// </summary>
    public class ContactServiceHostFactory : ServiceHostFactory
    {
        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost" /> for a specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">Specifies the type of service to host.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array" /> of type <see cref="T:System.Uri" /> that contains the base addresses for the service hosted.</param>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.ServiceHost" /> for the type of service specified with a specific base address.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceHost = new UnityServiceHost(serviceType, baseAddresses);
            var container = new UnityContainer();
            serviceHost.Container = container;

            container.RegisterType<IPersistenceServiceOf_Contact, PersistenceServiceOf_ContactClient>(new InjectionConstructor());

            return serviceHost;
        }
    }
}