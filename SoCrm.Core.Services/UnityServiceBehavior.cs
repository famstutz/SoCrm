// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityServiceBehavior.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The unity service behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Core.Services
{
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The unity service behavior.
    /// </summary>
    public class UnityServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceBehavior"/> class.
        /// </summary>
        public UnityServiceBehavior()
        {
            this.InstanceProvider = new UnityInstanceProvider();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceBehavior"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityServiceBehavior(UnityContainer container)
        {
            this.InstanceProvider = new UnityInstanceProvider { Container = container };
        }

        /// <summary>
        /// Gets or sets the instance provider.
        /// </summary>
        /// <value>
        /// The instance provider.
        /// </value>
        public UnityInstanceProvider InstanceProvider { get; set; }

        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects such as error handlers, message or parameter interceptors, security extensions, and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host that is currently being built.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;

                if (channelDispatcher != null)
                {
                    foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        this.InstanceProvider.ServiceType = serviceDescription.ServiceType;
                        endpointDispatcher.DispatchRuntime.InstanceProvider = this.InstanceProvider;
                    }
                }
            }
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description of the service.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }
    }
}
