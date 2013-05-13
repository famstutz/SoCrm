namespace SoCrm.Presentation.Security.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Security.CreateUser;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    [TestFixture]
    public class CreateUserViewModelTests
    {
        private CreateUserViewModel createUserViewModel;

        private Mock<ISecurityController> securityControllerMock;

        private Mock<ISecurityService> securityServiceMock;

        [SetUp]
        public void SetUp()
        {
            this.securityControllerMock = new Mock<ISecurityController>();
            this.securityServiceMock = new Mock<ISecurityService>();
            this.securityServiceMock.Setup(s => s.GetAllRoles())
                .Returns(
                    new List<Role>
                        {
                            Services.Security.Contracts.Role.Administrator,
                            Services.Security.Contracts.Role.User
                        });
            this.createUserViewModel = new CreateUserViewModel(
                this.securityControllerMock.Object, this.securityServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createUserViewModel = null;
            this.securityControllerMock = null;
            this.securityServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createUserViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.createUserViewModel.CreateUserCommand);
        }

        [Test]
        public void Role()
        {
            var role = Services.Security.Contracts.Role.Administrator;

            this.createUserViewModel.Role = role;
            var result = this.createUserViewModel.Role;

            Assert.AreEqual(role, result);
        }

        [Test]
        public void UserName()
        {
            var userName = "Florian";

            this.createUserViewModel.UserName = userName;
            var result = this.createUserViewModel.UserName;

            Assert.AreEqual(userName, result);
        }

        [Test]
        public void Password()
        {
            var password = "SuperSecretPW";

            this.createUserViewModel.Password = password;
            var result = this.createUserViewModel.Password;

            Assert.AreEqual(password, result);
        }

        [Test]
        public void Roles()
        {
            var roles = new ObservableCollection<Role>
                            {
                                Services.Security.Contracts.Role.User,
                                Services.Security.Contracts.Role.Administrator
                            };

            this.createUserViewModel.Roles = roles;
            var result = this.createUserViewModel.Roles;

            Assert.AreEqual(roles, result);
        }

        [Test]
        public void CreateUserCommandExecute()
        {
            var userName = "Florian";
            var password = "SecretPW";
            var role = Services.Security.Contracts.Role.Administrator;
            this.createUserViewModel.UserName = userName;
            this.createUserViewModel.Password = password;
            this.createUserViewModel.Role = role;

            this.securityServiceMock.Setup(s => s.CreateUser(userName, password, role));
            this.securityControllerMock.Setup(s => s.SetLastStatus(It.IsAny<string>()));

            this.createUserViewModel.CreateUserCommand.Execute(null);

            this.securityServiceMock.Verify(s => s.CreateUser(userName, password, role));
            this.securityControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.securityControllerMock.Verify(s => s.NavigateToUserList());
        }
    }
}
