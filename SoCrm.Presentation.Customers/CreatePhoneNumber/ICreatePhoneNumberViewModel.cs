namespace SoCrm.Presentation.Customers.CreatePhoneNumber
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    public interface ICreatePhoneNumberViewModel : IViewModelBase
    {
        string Number { get; set; }

        ObservableCollection<ContactType> ContactTypes { get; set; }
        ContactType ContactType { get; set; }
        ICommand CreatePhoneNumberCommand { get; }
    }
}
