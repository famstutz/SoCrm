namespace SoCrm.Presentation.Customers.CreateEMailAddress
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Customers.Customer;

    public interface ICreateEMailAddressViewModel : IViewModelBase
    {
        string Address { get; set; }

        ObservableCollection<ContactType> ContactTypes { get; set; }
        ContactType ContactType { get; set; }
        ICommand CreateEMailAddressCommand { get; }
    }
}
