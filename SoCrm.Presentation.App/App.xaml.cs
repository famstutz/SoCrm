using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SoCrm.Presentation.App
{
    using SoCrm.Presentation.App.Container;
    using SoCrm.Presentation.App.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = new MicrokernelContainer();

            container.RegisterA<IMainViewModel>(typeof(MainViewModel));
            container.RegisterA<IUserListViewModel>(typeof(UserListViewModel));
            container.RegisterA<ICreateUserViewModel>(typeof(CreateUserViewModel));

            Container.Container.InitializeContainerWith(container);
        }
    }
}
