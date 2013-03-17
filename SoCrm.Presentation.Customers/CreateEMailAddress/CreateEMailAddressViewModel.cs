// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateEMailAddressViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create e mail address view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreateEMailAddress
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create e mail address view model.
    /// </summary>
    public class CreateEMailAddressViewModel : ViewModelBase, ICreateEMailAddressViewModel
    {
        /// <summary>
        /// The customer controller.
        /// </summary>
        private readonly ICustomerController customerController;

        /// <summary>
        /// The customer service.
        /// </summary>
        private readonly ICustomerService customerService;

        /// <summary>
        /// The address.
        /// </summary>
        private string address;

        /// <summary>
        /// The contact types.
        /// </summary>
        private ObservableCollection<ContactType> contactTypes;

        /// <summary>
        /// The contact type.
        /// </summary>
        private ContactType contactType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEMailAddressViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CreateEMailAddressViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreateEMailAddressCommand = new CommandModel(this.OnCreateEMailAddress);

            this.ContactTypes = new ObservableCollection<ContactType>(this.customerService.GetContactTypes());
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (this.address != value)
                {
                    this.address = value;
                    this.OnPropertyChanged("Address");
                }
            }
        }

        /// <summary>
        /// Gets or sets the contact types.
        /// </summary>
        /// <value>
        /// The contact types.
        /// </value>
        public ObservableCollection<ContactType> ContactTypes
        {
            get
            {
                return this.contactTypes;
            }

            set
            {
                if (this.contactTypes != value)
                {
                    this.contactTypes = value;
                    this.OnPropertyChanged("ContactTypes");
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        public ContactType ContactType
        {
            get
            {
                return this.contactType;
            }

            set
            {
                if (this.contactType != value)
                {
                    this.contactType = value;
                    this.OnPropertyChanged("ContactType");
                }
            }
        }

        /// <summary>
        /// Gets the create E mail address command.
        /// </summary>
        /// <value>
        /// The create E mail address command.
        /// </value>
        public ICommand CreateEMailAddressCommand { get; private set; }

        /// <summary>
        /// Called when e mail address is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreateEMailAddress(object obj)
        {
            var emailAddress = this.customerService.CreateEmailAddress(this.Address, this.ContactType);
            this.customerController.SetLastStatus(string.Format("Successfully created e-mail address {0}.", emailAddress.Address));
            this.customerController.NavigateBackToCreateCustomer(emailAddress);
        }
    }
}
