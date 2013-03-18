// --------------------------------------------------------------------------------------------------------------------
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
    using SoCrm.Presentation.Contacts.ContactList;
    using SoCrm.Presentation.Contacts.CreateContact;
    using SoCrm.Presentation.Contacts.Customer;
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

            container.RegisterType<IContactListViewModel, ContactListViewModel>();
            container.RegisterType<ICreateContactViewModel, CreateContactViewModel>();

            container.RegisterInstance(typeof(IContactService), new ContactServiceClient(), new ContainerControlledLifetimeManager());
            container.RegisterInstance(typeof(ICustomerService), new CustomerServiceClient(), new ContainerControlledLifetimeManager());
        }
    }
}
