// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactController.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Contacts.ContactList;
    using SoCrm.Presentation.Contacts.CreateContact;
    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The contact controller.
    /// </summary>
    public class ContactController : ControllerBase, IContactController
    {
            /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="mainRegion">The main region.</param>
        public ContactController(IUnityContainer container, [Dependency(RegionNames.MainRegion)] IRegion mainRegion)
            : base(container, mainRegion)
        {
            this.container = container;
        }

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        /// <param name="person">The person.</param>
        public void NavigateToCreateContact(Person person)
        {
            var createContactViewModel = this.container.Resolve<ICreateContactViewModel>();
            createContactViewModel.Person = person;
            this.MainRegion.Context = createContactViewModel;
        }

        /// <summary>
        /// Navigates to create contact.
        /// </summary>
        public void NavigateToCreateContact()
        {
            var createContactViewModel = this.container.Resolve<ICreateContactViewModel>();
            this.MainRegion.Context = createContactViewModel;
        }

        /// <summary>
        /// Navigates to contact list.
        /// </summary>
        public void NavigateToContactList()
        {
            var contactListViewModel = this.container.Resolve<IContactListViewModel>();
            this.MainRegion.Context = contactListViewModel;
        }
    }
}
