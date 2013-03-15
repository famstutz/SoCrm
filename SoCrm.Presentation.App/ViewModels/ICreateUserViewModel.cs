namespace SoCrm.Presentation.App.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Services.Security.Contracts;

    public interface ICreateUserViewModel : IViewModelBase
    {
        Role Role { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        ObservableCollection<Role> Roles { get; set; }
        ICommand CreateUserCommand { get; }
    }
}
