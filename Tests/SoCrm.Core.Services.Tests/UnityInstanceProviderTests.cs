namespace SoCrm.Core.Services.Tests
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    [TestFixture]
    public class UnityInstanceProviderTests
    {
        [Test]
        public void Constructor()
        {
            var unityInstanceProvider = new UnityInstanceProvider();

            Assert.IsNotNull(unityInstanceProvider);
        }

        [Test]
        public void Constructor_Type()
        {
            var type = typeof(string);
            var unityInstanceProvider = new UnityInstanceProvider(type);

            Assert.IsNotNull(unityInstanceProvider);
            Assert.AreEqual(type, unityInstanceProvider.ServiceType);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var unityInstanceProvider = new UnityInstanceProvider();

            Assert.IsNotNull(unityInstanceProvider.Container);
        }

        [Test]
        public void SetContainer()
        {
            var unityInstanceProvider = new UnityInstanceProvider();
            var container = new UnityContainer();

            unityInstanceProvider.Container = container;

            Assert.AreEqual(container, unityInstanceProvider.Container);
        }

        [Test]
        public void SetServiceType()
        {
            var unityInstanceProvider = new UnityInstanceProvider();
            var type = typeof(string);

            unityInstanceProvider.ServiceType = type;

            Assert.AreEqual(type, unityInstanceProvider.ServiceType);
        }
    }
}
