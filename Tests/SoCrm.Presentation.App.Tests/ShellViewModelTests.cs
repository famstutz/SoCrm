namespace SoCrm.Presentation.App.Tests
{
    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.App.Shell;
    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Security.Authentication;

    [TestFixture]
    public class ShellViewModelTests
    {
        private IUnityContainer unityContainer;

        private Mock<IAppController> appControllerMock;

        private Mock<IStatusBarService> statusBarServiceMock;

        private Mock<IAuthenticationService> authenticationServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.appControllerMock = new Mock<IAppController>();
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.authenticationServiceMock = new Mock<IAuthenticationService>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.appControllerMock.Object);
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
            this.unityContainer.RegisterInstance(this.authenticationServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.appControllerMock = null;
            this.statusBarServiceMock = null;
            this.authenticationServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            var shellViewModel = new ShellViewModel(this.unityContainer);

            Assert.IsNotNull(shellViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var shellViewModel = new ShellViewModel(this.unityContainer);

            Assert.IsInstanceOf<IRegion>(shellViewModel.MainRegion);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.UserListCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.CreateUserCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.CustomerListCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.CreateCustomerCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.CompanyListCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.AuthenticationCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.ContactListCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.CreateContactCommand);
            Assert.IsInstanceOf<CommandModel>(shellViewModel.ExitCommand);
        }

        [Test]
        public void SetAuthenticationService()
        {
            var authenticationService = new AuthenticationService();
            var shellViewModel = new ShellViewModel(this.unityContainer);

            shellViewModel.AuthenticationService = authenticationService;

            Assert.AreEqual(authenticationService, shellViewModel.AuthenticationService);
        }

        [Test]
        public void SetStatusBarService()
        {
            var statusBarService = new StatusBarService();
            var shellViewModel = new ShellViewModel(this.unityContainer);

            shellViewModel.StatusBarService = statusBarService;

            Assert.AreEqual(statusBarService, shellViewModel.StatusBarService);
        }
    }
}
