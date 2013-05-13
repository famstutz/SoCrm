namespace SoCrm.Presentation.Security.Tests
{
    using System;

    using NUnit.Framework;

    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Services.Security.Contracts;

    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService authenticationService;

        [SetUp]
        public void SetUp()
        {
            this.authenticationService = new AuthenticationService();
        }

        [TearDown]
        public void TearDown()
        {
            this.authenticationService = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.authenticationService);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsUserLoggedOn()
        {
            var result = this.authenticationService.IsUserLoggedOn;

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CurrentUser()
        {
            var user = new User
                           {
                               ObjectId = Guid.NewGuid(),
                               UserName = "Florian",
                               Password = "SecretPW",
                               Role = Role.Administrator
                           };

            this.authenticationService.CurrentUser = user;
            var result = this.authenticationService.CurrentUser;

            Assert.AreEqual(user, result);
        }
    }
}
