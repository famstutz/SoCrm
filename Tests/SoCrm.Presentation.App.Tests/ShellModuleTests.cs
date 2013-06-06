namespace SoCrm.Presentation.App.Tests
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using SoCrm.Presentation.App.Shell;
    using SoCrm.Presentation.Core.StatusBar;

    [TestFixture]
    public class ShellModuleTests
    {
        [Test]
        public void Constructor()
        {
            var shellModule = new ShellModule();

            Assert.IsNotNull(shellModule);
        }

        [Test]
        public void Register()
        {
            var unityContainer = new UnityContainer();
            var shellModule = new ShellModule();

            shellModule.Register(unityContainer);

            Assert.IsTrue(unityContainer.IsRegistered<IShellViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<IAppController>());
            Assert.IsTrue(unityContainer.IsRegistered<IStatusBarService>());
        }
    }
}
