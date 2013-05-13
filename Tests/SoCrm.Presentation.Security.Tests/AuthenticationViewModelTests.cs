namespace SoCrm.Presentation.Security.Tests
{
    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Core;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Presentation.Security.Security;

    [TestFixture]
    public class AuthenticationViewModelTests
    {
        private Mock<ISecurityController> securityControllerMock;

        private Mock<ISecurityService> securityServiceMock;

        private Mock<IAuthenticationService> authenticationServiceMock;

        private AuthenticationViewModel authenticationViewModel;

        [SetUp]
        public void SetUp()
        {
            this.securityControllerMock = new Mock<ISecurityController>();
            this.securityServiceMock = new Mock<ISecurityService>();
            this.authenticationServiceMock = new Mock<IAuthenticationService>();
            this.authenticationViewModel = new AuthenticationViewModel(
                securityControllerMock.Object, securityServiceMock.Object, authenticationServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.authenticationViewModel = null;
            this.securityControllerMock = null;
            this.securityServiceMock = null;
            this.authenticationServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.authenticationViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.authenticationViewModel.LogOnCommand);
        }

        [Test]
        public void UserName()
        {
            var userName = "Florian";

            this.authenticationViewModel.UserName = userName;
            var result = this.authenticationViewModel.UserName;

            Assert.AreEqual(userName, result);
        }

        [Test]
        public void Password()
        {
            var password = "secretPW";

            this.authenticationViewModel.Password = password;
            var result = this.authenticationViewModel.Password;

            Assert.AreEqual(password, result);
        }

        [Test]
        public void LogOnCommandExecute_ValidCredentials()
        {
            var userName = "Florian";
            var password = "SecretPassword";
            this.authenticationViewModel.UserName = userName;
            this.authenticationViewModel.Password = password;

            this.securityServiceMock.Setup(s => s.ValidateCredentials(userName, password)).Returns(true);

            this.authenticationViewModel.LogOnCommand.Execute(null);

            this.securityServiceMock.Verify(s => s.ValidateCredentials(userName, password));
            this.securityControllerMock.Verify(s => s.ClearMainRegion());
            this.securityControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void LogOnCommandExecute_InvalidCredentials()
        {
            var userName = "Florian";
            var password = "SecretPassword";
            this.authenticationViewModel.UserName = userName;
            this.authenticationViewModel.Password = password;

            this.securityServiceMock.Setup(s => s.ValidateCredentials(userName, password)).Returns(false);

            this.authenticationViewModel.LogOnCommand.Execute(null);

            this.securityControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }
    }
}
