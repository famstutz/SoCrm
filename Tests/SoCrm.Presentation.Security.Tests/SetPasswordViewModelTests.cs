namespace SoCrm.Presentation.Security.Tests
{
    using System;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Security.SetPassword;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    [TestFixture]
    public class SetPasswordViewModelTests
    {
        private SetPasswordViewModel setPasswordViewModel;

        private Mock<ISecurityController> securityControllerMock;

        private Mock<ISecurityService> securityServiceMock;

        private User user;

        [SetUp]
        public void SetUp()
        {
            this.securityControllerMock = new Mock<ISecurityController>();
            this.securityServiceMock = new Mock<ISecurityService>();
            this.user = new User
                            {
                                ObjectId = Guid.NewGuid(),
                                UserName = "Florian",
                                Password = "Test123",
                                Role = Role.Administrator
                            };
            this.setPasswordViewModel = new SetPasswordViewModel(
                this.securityControllerMock.Object, this.securityServiceMock.Object, this.user);
        }

        [TearDown]
        public void TearDown()
        {
            this.setPasswordViewModel = null;
            this.securityControllerMock = null;
            this.securityServiceMock = null;
            this.user = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.setPasswordViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.setPasswordViewModel.SetPasswordCommand);
            Assert.AreEqual(this.user, this.setPasswordViewModel.User);
        }

        [Test]
        public void User()
        {
            var newUser = new User
                           {
                               ObjectId = Guid.NewGuid(),
                               UserName = "Peter",
                               Password = "Geheimnis",
                               Role = Role.User
                           };

            this.setPasswordViewModel.User = newUser;
            var result = this.setPasswordViewModel.User;

            Assert.AreEqual(newUser, result);
        }

        [Test]
        public void OldPassword()
        {
            var password = "Test123**";

            this.setPasswordViewModel.OldPassword = password;
            var result = this.setPasswordViewModel.OldPassword;

            Assert.AreEqual(password, result);
        }

        [Test]
        public void NewPassword()
        {
            var password = "Test123**";

            this.setPasswordViewModel.NewPassword = password;
            var result = this.setPasswordViewModel.NewPassword;

            Assert.AreEqual(password, result);
        }

        [Test]
        public void SetPasswordCommandExecute()
        {
            var password = "SecretPW";
            this.setPasswordViewModel.OldPassword = this.user.Password;
            this.setPasswordViewModel.NewPassword = password;

            this.securityServiceMock.Setup(
                s =>
                s.SetPassword(
                    this.setPasswordViewModel.User,
                    this.setPasswordViewModel.OldPassword,
                    this.setPasswordViewModel.NewPassword));
            this.securityControllerMock.Setup(s => s.SetLastStatus(It.IsAny<string>()));

            this.setPasswordViewModel.SetPasswordCommand.Execute(null);

            this.securityServiceMock.Verify(
                s =>
                s.SetPassword(
                    this.setPasswordViewModel.User,
                    this.setPasswordViewModel.OldPassword,
                    this.setPasswordViewModel.NewPassword));
            this.securityControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.securityControllerMock.Verify(s => s.NavigateToUserList());
        }
    }
}
