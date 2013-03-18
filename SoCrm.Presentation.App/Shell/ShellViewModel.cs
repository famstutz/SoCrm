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
    using System;
    using System.Windows.Input;

    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Security.Authentication;

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
        /// The authentication service.
        /// </summary>
        private IAuthenticationService authenticationService;

        /// <summary>
        /// The status bar service.
        /// </summary>
        private IStatusBarService statusBarService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ShellViewModel(IUnityContainer container)
        {
            this.appController = container.Resolve<IAppController>();
            this.statusBarService = container.Resolve<IStatusBarService>();
            this.authenticationService = container.Resolve<IAuthenticationService>();

            this.MainRegion = new RegionModel();
            container.RegisterInstance(RegionNames.MainRegion, this.MainRegion, new ContainerControlledLifetimeManager());
            container.RegisterInstance(this.MainRegion, new ContainerControlledLifetimeManager());
            
            this.UserListCommand = new CommandModel(obj => this.appController.NavigateToUserList());
            this.CreateUserCommand = new CommandModel(obj => this.appController.NavigateToCreateUser());
            this.CustomerListCommand = new CommandModel(obj => this.appController.NavigateToCustomerList());
            this.CreateCustomerCommand = new CommandModel(obj => this.appController.NavigateToCreateCustomer());
            this.CompanyListCommand = new CommandModel(obj => this.appController.NavigateToCompanyList());
            this.AuthenticationCommand = new CommandModel(obj => this.appController.NavigateToAuthentication());
            this.ExitCommand = new CommandModel(obj => this.Closing(this, EventArgs.Empty));
        }

        /// <summary>
        /// Occurs when closing.
        /// </summary>
        public event EventHandler Closing;

        /// <summary>
        /// Gets or sets the authentication service.
        /// </summary>
        /// <value>
        /// The authentication service.
        /// </value>
        public IAuthenticationService AuthenticationService
        {
            get
            {
                return this.authenticationService;
            }

            set
            {
                if (this.authenticationService != value)
                {
                    this.authenticationService = value;
                    this.OnPropertyChanged("AuthenticationService");
                }
            }
        }

        /// <summary>
        /// Gets or sets the status bar service.
        /// </summary>
        /// <value>
        /// The status bar service.
        /// </value>
        public IStatusBarService StatusBarService
        {
            get
            {
                return this.statusBarService;
            }

            set
            {
                if (this.statusBarService != value)
                {
                    this.statusBarService = value;
                    this.OnPropertyChanged("StatusBarService");
                }
            }
        }

        /// <summary>
        /// Gets the customer list command.
        /// </summary>
        /// <value>
        /// The customer list command.
        /// </value>
        public ICommand CustomerListCommand { get; private set; }

        /// <summary>
        /// Gets the exit command.
        /// </summary>
        /// <value>
        /// The exit command.
        /// </value>
        public ICommand ExitCommand { get; private set; }

        /// <summary>
        /// Gets the company list command.
        /// </summary>
        /// <value>
        /// The company list command.
        /// </value>
        public ICommand CompanyListCommand { get; private set; }

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
        /// Gets the create customer command.
        /// </summary>
        /// <value>
        /// The create customer command.
        /// </value>
        public ICommand CreateCustomerCommand { get; private set; }

        /// <summary>
        /// Gets the authentication command.
        /// </summary>
        /// <value>
        /// The authentication command.
        /// </value>
        public ICommand AuthenticationCommand { get; private set; }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            var shell = new ShellView { DataContext = this };
            shell.Show();
        }

        /// <summary>
        /// Raises the <see cref="E:Closing" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClosing(EventArgs e)
        {
            EventHandler handler = this.Closing;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}