namespace SoCrm.Core.Services.Tests
{
    using System;

    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    [TestFixture]
    public class UnityServiceHostTests
    {
        [Test]
        public void Constuctor()
        {
            var unityServiceHost = new UnityServiceHost();

            Assert.IsNotNull(unityServiceHost);
        }

        [Test]
        public void Constructor_ServiceType_BaseAddresses()
        {
            var type = typeof(string);
            var baseAddresses = new [] { new Uri("http://localhost/") };
            var unityServiceHost = new UnityServiceHost(type, baseAddresses);

            Assert.IsNotNull(unityServiceHost);
        }
        
        [Test]
        public void PropertiesDefaultValues()
        {
            var unityServiceHost = new UnityServiceHost();

            Assert.IsNotNull(unityServiceHost.Container);
        }

        [Test]
        public void SetContainer()
        {
            var unityServiceHost = new UnityServiceHost();
            var container = new UnityContainer();

            unityServiceHost.Container = container;

            Assert.AreEqual(container, unityServiceHost.Container);
        }
    }
}
