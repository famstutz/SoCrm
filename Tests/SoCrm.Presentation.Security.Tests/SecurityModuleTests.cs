namespace SoCrm.Presentation.Security.Tests
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using SoCrm.Presentation.Security;
    using SoCrm.Presentation.Security.Authentication;
    using SoCrm.Presentation.Security.CreateUser;
    using SoCrm.Presentation.Security.Security;
    using SoCrm.Presentation.Security.SetPassword;
    using SoCrm.Presentation.Security.UserList;

    [TestFixture]
    public class SecurityModuleTests
    {
        [Test]
        public void Constructor()
        {
            var securityModule = new SecurityModule();

            Assert.IsNotNull(securityModule);
        }

        [Test]
        public void Register()
        {
            var unityContainer = new UnityContainer();
            var securityModule = new SecurityModule();

            securityModule.Register(unityContainer);

            Assert.IsTrue(unityContainer.IsRegistered<ISecurityController>());
            Assert.IsTrue(unityContainer.IsRegistered<IAuthenticationService>());
            Assert.IsTrue(unityContainer.IsRegistered<IUserListViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreateUserViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ISetPasswordViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<IAuthenticationViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ISecurityService>());
        }
    }
}
