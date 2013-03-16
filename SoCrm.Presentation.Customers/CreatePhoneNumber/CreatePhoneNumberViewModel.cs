// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreatePhoneNumberViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The create phone number view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.CreatePhoneNumber
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    /// <summary>
    /// The create phone number view model.
    /// </summary>
    public class CreatePhoneNumberViewModel : ViewModelBase, ICreatePhoneNumberViewModel
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
        /// The number.
        /// </summary>
        private string number;

        /// <summary>
        /// The contact types.
        /// </summary>
        private ObservableCollection<ContactType> contactTypes;

        /// <summary>
        /// The contact type.
        /// </summary>
        private ContactType contactType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePhoneNumberViewModel"/> class.
        /// </summary>
        /// <param name="customerController">The customer controller.</param>
        /// <param name="customerService">The customer service.</param>
        public CreatePhoneNumberViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreatePhoneNumberCommand = new CommandModel(this.OnCreatePhoneNumber);

            this.ContactTypes = new ObservableCollection<ContactType>(this.customerService.GetContactTypes());
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    this.OnPropertyChanged("Number");
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
        /// Gets the create phone number command.
        /// </summary>
        /// <value>
        /// The create phone number command.
        /// </value>
        public ICommand CreatePhoneNumberCommand { get; private set; }

        /// <summary>
        /// Called when phone number is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnCreatePhoneNumber(object obj)
        {
            var phoneNumber = this.customerService.CreatePhoneNumber(this.Number, this.ContactType);
            this.customerController.NavigateBackToCreateCustomer(phoneNumber);
        }
    }
}
