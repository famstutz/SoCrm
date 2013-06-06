namespace SoCrm.Core.Services.Tests
{
    using System.Collections.ObjectModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;

    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    [TestFixture]
    public class UnityServiceBehavoirTests
    {
        [Test]
        public void Constructor()
        {
            var unityServiceBehavior = new UnityServiceBehavior();

            Assert.IsNotNull(unityServiceBehavior);
        }

        [Test]
        public void Constructor_Container()
        {
            var container = new UnityContainer();
            var unityServiceBehavior = new UnityServiceBehavior(container);

            Assert.IsNotNull(unityServiceBehavior);
            Assert.AreEqual(container, unityServiceBehavior.InstanceProvider.Container);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var unityServiceBehavior = new UnityServiceBehavior();

            Assert.IsNotNull(unityServiceBehavior.InstanceProvider);
        }

        [Test]
        public void SetInstanceProvider()
        {
            var unityServiceBehavior = new UnityServiceBehavior();
            var instanceProvider = new UnityInstanceProvider();

            unityServiceBehavior.InstanceProvider = instanceProvider;

            Assert.AreEqual(instanceProvider, unityServiceBehavior.InstanceProvider);
        }

        [Test]
        public void ApplyDispatchBehavior()
        {
            var unityServiceBehavior = new UnityServiceBehavior();
            var serviceDescription = new ServiceDescription { ServiceType = typeof(string) };
            var unityServiceHost = new UnityServiceHost();
            
            unityServiceBehavior.ApplyDispatchBehavior(serviceDescription, unityServiceHost);
        }

        [Test]
        public void Validate()
        {
            var unityServiceBehavior = new UnityServiceBehavior();
            var serviceDescription = new ServiceDescription { ServiceType = typeof(string) };
            var unityServiceHost = new UnityServiceHost();

            unityServiceBehavior.Validate(serviceDescription, unityServiceHost);
        }

        [Test]
        public void AddBindingParameters()
        {
            var unityServiceBehavior = new UnityServiceBehavior();
            var serviceDescription = new ServiceDescription { ServiceType = typeof(string) };
            var unityServiceHost = new UnityServiceHost();

            unityServiceBehavior.AddBindingParameters(serviceDescription, unityServiceHost, new Collection<ServiceEndpoint>(), new BindingParameterCollection());
        }
    }
}
