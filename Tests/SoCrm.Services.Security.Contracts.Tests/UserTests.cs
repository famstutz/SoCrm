namespace SoCrm.Services.Security.Contracts.Tests
{
    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor()
        {
            var user = new User();

            Assert.IsNotNull(user);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var user = new User();

            AssertExtensions.IsDefault(user.UserName);
            AssertExtensions.IsDefault(user.Role);
            AssertExtensions.IsDefault(user.Password);
        }

        [Test]
        public void SetUserName()
        {
            var user = new User();
            var userName = "Hans";
            user.UserName = userName;

            Assert.AreEqual(userName, user.UserName);
        }

        [Test]
        public void SetRole()
        {
            var user = new User();
            var role = Role.Administrator;
            user.Role = role;

            Assert.AreEqual(role, user.Role);
        }

        [Test]
        public void SetPassword()
        {
            var user = new User();
            var password = "SecretPassword";
            user.Password = password;

            Assert.AreEqual(password, user.Password);
        }
    }
}
