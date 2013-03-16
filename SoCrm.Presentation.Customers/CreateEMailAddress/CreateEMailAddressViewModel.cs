namespace SoCrm.Presentation.Customers.CreateEMailAddress
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    public class CreateEMailAddressViewModel : ViewModelBase, ICreateEMailAddressViewModel
    {
        private readonly ICustomerController customerController;

        private readonly ICustomerService customerService;

        private string address;

        private ObservableCollection<ContactType> contactTypes;

        private ContactType contactType;

        public CreateEMailAddressViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreateEMailAddressCommand = new CommandModel(this.OnCreateEMailAddress);

            this.ContactTypes = new ObservableCollection<ContactType>(this.customerService.GetContactTypes());
        }

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

        public ICommand CreateEMailAddressCommand { get; private set; }

        private void OnCreateEMailAddress(object obj)
        {
            var emailAddress = this.customerService.CreateEmailAddress(this.Address, this.ContactType);
            this.customerController.NavigateBackToCreateCustomer(emailAddress);
        }
    }
}
