namespace SoCrm.Presentation.Core.Tests
{
    using System;

    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using SoCrm.Presentation.App;

    [TestFixture]
    public class BootstrapperTests
    {
        private IUnityContainer unityContainer;

        [SetUp]
        public void SetUp()
        {
            this.unityContainer = new UnityContainer();
        }
        
        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
        }

        [Test]
        public void Constructor()
        {
            var bootstrapper = new Bootstrapper(this.unityContainer);

            Assert.IsNotNull(bootstrapper);
        }

        [Test]
        public void RegisterModule()
        {
            var bootstrapper = new Bootstrapper(this.unityContainer);

            bootstrapper.RegisterModule(typeof(ShellModule));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterModule_ArgumentException()
        {
            this.unityContainer.RegisterInstance(123);
            var bootstrapper = new Bootstrapper(this.unityContainer);

            bootstrapper.RegisterModule(typeof(int));
        }
    }
}
