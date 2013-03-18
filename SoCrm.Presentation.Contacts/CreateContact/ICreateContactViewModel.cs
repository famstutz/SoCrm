// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateContactViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create contact view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Contacts.CreateContact
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The create contact view model.
    /// </summary>
    public interface ICreateContactViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        ObservableCollection<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        Person Person { get; set; }

        /// <summary>
        /// Gets or sets the contact mediums.
        /// </summary>
        /// <value>
        /// The contact mediums.
        /// </value>
        ObservableCollection<ContactMedium> ContactMediums { get; set; }

        /// <summary>
        /// Gets or sets the contact medium.
        /// </summary>
        /// <value>
        /// The contact medium.
        /// </value>
        ContactMedium ContactMedium { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        DateTime DateTime { get; set; }

        /// <summary>
        /// Gets the create contact command.
        /// </summary>
        /// <value>
        /// The create contact command.
        /// </value>
        ICommand CreateContactCommand { get; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        User User { get; }
    }
}
