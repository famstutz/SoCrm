namespace SoCrm.Presentation.App.ViewModels
{
    using System.Windows.Input;

    public interface IMainViewModel : IViewModelBase
    {
        object CurrentView { get; }
        ICommand NavigateToUserListCommand { get; }
        ICommand NavigateToCreateUserCommand { get; }
        void NavigateToView(object viewToNavigate);
    }
}
