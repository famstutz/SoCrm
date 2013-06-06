namespace SoCrm.Presentation.Security.Tests
{
    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Presentation.Security.CreateUser;
    using SoCrm.Presentation.Security.SetPassword;
    using SoCrm.Presentation.Security.UserList;
    using SoCrm.Services.Security.Contracts;

    [TestFixture]
    public class SecurityControllerTests
    {
        private IUnityContainer unityContainer;

        private Mock<IStatusBarService> statusBarServiceMock;

        private Mock<IRegion> regionMock;

        private Mock<IUserListViewModel> userListViewModelMock;

        private Mock<ICreateUserViewModel> createUserViewModelMock;

        private Mock<ISetPasswordViewModel> setPasswordViewModelMock;

        private Mock<IAuthenticationViewModel> authenticationViewModelMock;

        [SetUp]
        public void SetUp()
        {
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.regionMock = new Mock<IRegion>();
            this.userListViewModelMock = new Mock<IUserListViewModel>();
            this.createUserViewModelMock = new Mock<ICreateUserViewModel>();
            this.setPasswordViewModelMock = new Mock<ISetPasswordViewModel>();
            this.authenticationViewModelMock = new Mock<IAuthenticationViewModel>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
            this.unityContainer.RegisterInstance(this.userListViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.createUserViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.setPasswordViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.authenticationViewModelMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.regionMock = null;
            this.userListViewModelMock = null;
            this.createUserViewModelMock = null;
            this.setPasswordViewModelMock = null;
            this.authenticationViewModelMock = null;
            this.statusBarServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            var securityController = new SecurityController(this.unityContainer, this.regionMock.Object);

            Assert.IsNotNull(securityController);
        }

        [Test]
        public void NavigateToUserList()
        {
            this.regionMock.SetupSet(r => r.Context = this.userListViewModelMock.Object).Verifiable();
            var securityController = new SecurityController(this.unityContainer, this.regionMock.Object);

            securityController.NavigateToUserList();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateUser()
        {
            this.regionMock.SetupSet(r => r.Context = this.createUserViewModelMock.Object).Verifiable();
            var securityController = new SecurityController(this.unityContainer, this.regionMock.Object);

            securityController.NavigateToCreateUser();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToSetPassword()
        {
            var user = new User();
            this.regionMock.SetupSet(r => r.Context = this.setPasswordViewModelMock.Object).Verifiable();
            var securityController = new SecurityController(this.unityContainer, this.regionMock.Object);

            securityController.NavigateToSetPassword(user);

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToAuthentication()
        {
            this.regionMock.SetupSet(r => r.Context = this.authenticationViewModelMock.Object).Verifiable();
            var securityController = new SecurityController(this.unityContainer, this.regionMock.Object);

            securityController.NavigateToAuthentication();

            this.regionMock.Verify();
        }
    }
}
