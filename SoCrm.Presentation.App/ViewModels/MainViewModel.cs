namespace SoCrm.Presentation.App.ViewModels
{
    using System.Windows.Controls;
    using System.Windows.Input;

    using SoCrm.Presentation.App.Commands;
    using SoCrm.Presentation.App.Views;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            private set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public ICommand NavigateToUserListCommand
        {
            get
            {
                return new NavigateToViewCommand(Container.Container.GetA<IUserListViewModel>());
            }
        }

        public ICommand NavigateToCreateUserCommand
        {
            get
            {
                return new NavigateToViewCommand(Container.Container.GetA<ICreateUserViewModel>());
            }
        }

        public void NavigateToView(object viewToNavigate)
        {
            CurrentView = viewToNavigate;
        }
    }
}