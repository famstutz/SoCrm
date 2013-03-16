// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   Interaction logic for App.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App
{
    using System.Windows;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.App.Shell;
    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Customers;
    using SoCrm.Presentation.Security;

    /// <summary>
    /// Interaction logic for App.
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();

            container.Resolve<Bootstrapper>()
                     .RegisterModule(typeof(ShellModule))
                     .RegisterModule(typeof(SecurityModule))
                     .RegisterModule(typeof(CustomerModule));

            container.Resolve<IShellViewModel>().Show();
        }
    }
}
