namespace SoCrm.Presentation.Customers.CreatePhoneNumber
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers.Customer;

    public class CreatePhoneNumberViewModel : ViewModelBase, ICreatePhoneNumberViewModel
    {
         private readonly ICustomerController customerController;

        private readonly ICustomerService customerService;

        private string number;

        private ObservableCollection<ContactType> contactTypes;

        private ContactType contactType;

        public CreatePhoneNumberViewModel(ICustomerController customerController, ICustomerService customerService)
        {
            this.customerController = customerController;
            this.customerService = customerService;

            this.CreatePhoneNumberCommand = new CommandModel(this.OnCreatePhoneNumber);

            this.ContactTypes = new ObservableCollection<ContactType>(this.customerService.GetContactTypes());
        }

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

        public ICommand CreatePhoneNumberCommand { get; private set; }

        private void OnCreatePhoneNumber(object obj)
        {
            var phoneNumber = this.customerService.CreatePhoneNumber(this.Number, this.ContactType);
            this.customerController.NavigateBackToCreateCustomer(phoneNumber);
        }
    }
}
