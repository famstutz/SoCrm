// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The shell view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.App.Shell
{
    using System.Windows.Input;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;

    /// <summary>
    /// The shell view model.
    /// </summary>
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        /// <summary>
        /// The app controller.
        /// </summary>
        private readonly IAppController appController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ShellViewModel(IUnityContainer container)
        {
            this.appController = container.Resolve<IAppController>();

            this.MainRegion = new RegionModel();
            container.RegisterInstance(RegionNames.MainRegion, this.MainRegion, new ContainerControlledLifetimeManager());
            container.RegisterInstance(this.MainRegion, new ContainerControlledLifetimeManager());
            
            this.UserListCommand = new CommandModel(obj => this.appController.NavigateToUserList());
            this.CreateUserCommand = new CommandModel(obj => this.appController.NavigateToCreateUser());
            this.CustomerListCommand = new CommandModel(obj => this.appController.NavigateToCustomerList());
        }

        public ICommand CustomerListCommand { get; private set; }

        /// <summary>
        /// Gets the main region.
        /// </summary>
        /// <value>
        /// The main region.
        /// </value>
        public IRegion MainRegion { get; private set; }

        /// <summary>
        /// Gets the user list command.
        /// </summary>
        /// <value>
        /// The user list command.
        /// </value>
        public ICommand UserListCommand { get; private set; }

        /// <summary>
        /// Gets the create user command.
        /// </summary>
        /// <value>
        /// The create user command.
        /// </value>
        public ICommand CreateUserCommand { get; private set; }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            var shell = new ShellView { DataContext = this };
            shell.Show();
        }
    }
}