////////////////////////////////////////////////////////////////////////////////
//
// The content of this file is copyright (C) 2016 Geoplan
//
//
// Name : ServiceErrorBehaviourAttribute.cs
// Creation date: 20 Oct 2016
// Created by : alastair todd
// Comments : 
//


using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Skin.Framework.Logging.Wcf
{
    
    /// <summary>
    /// So we can decorate Services with the [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    /// ...and errors reported to ELMAH
    /// </summary>
    public class ServiceErrorBehaviourAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;

        public ServiceErrorBehaviourAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler;
            errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}