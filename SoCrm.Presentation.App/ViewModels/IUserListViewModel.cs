namespace SoCrm.Presentation.App.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Services.Security.Contracts;

    public interface IUserListViewModel : IViewModelBase
    {
        ObservableCollection<Role> Roles { get; set; }
        ObservableCollection<User> Users { get; set; }
        string SearchUserName { get; set; }
        Role SearchRole { get; set; }
        User SelectedUser { get; set; }
        ICommand SearchUsersCommand { get; set; }
        ICommand DeleteUserCommand { get; set; }
    }
}
