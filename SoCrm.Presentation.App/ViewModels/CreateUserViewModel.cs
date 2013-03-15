namespace SoCrm.Presentation.App.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using SoCrm.Presentation.App.Security;
    using SoCrm.Services.Security.Contracts;

    public class CreateUserViewModel : ViewModelBase, ICreateUserViewModel
    {
        private Role role;

        private string password;

        private string userName;

        private ObservableCollection<Role> roles;

        private readonly SecurityServiceClient securityServiceClient;

        public CreateUserViewModel()
        {
            this.CreateUserCommand = new RelayCommand(this.OnCreateUserCommand);

            this.securityServiceClient = new SecurityServiceClient();

            this.Roles = new ObservableCollection<Role>(this.securityServiceClient.GetAllRoles());
        }

        public Role Role
        {
            get
            {
                return this.role;
            }

            set
            {
                if (this.role != value)
                {
                    this.role = value;
                    this.OnPropertyChanged("Role");
                }
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (this.userName != value)
                {
                    this.userName = value;
                    this.OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {

            get
            {
                return this.password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged("Password");
                }
            }
        }

        public ObservableCollection<Role> Roles
        {
            get
            {
                return this.roles;
            }

            set
            {
                if (this.roles != value)
                {
                    this.roles = value;
                    this.OnPropertyChanged("Roles");
                }
            }
        }

        public ICommand CreateUserCommand { get; set; }

        private void OnCreateUserCommand(object obj)
        {
            this.securityServiceClient.CreateUser(this.UserName, this.Password, this.Role);
            Container.Container.GetA<IMainViewModel>().NavigateToView(Container.Container.GetA<IUserListViewModel>());
        }
    }
}
