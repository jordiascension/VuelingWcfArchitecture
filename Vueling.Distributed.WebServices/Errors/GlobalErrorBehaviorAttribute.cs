﻿using log4net;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace Vueling.Distributed.WebServices.Errors
{
    public class GlobalErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        private readonly Type errorHandlerType;

        /// <summary>
        /// Dependency injection to dynamically inject error handler 
        /// if we have multiple global error handlers
        /// </summary>
        /// <param name="errorHandlerType"></param>
        public GlobalErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        void IServiceBehavior.Validate(ServiceDescription description,
            ServiceHostBase serviceHostBase)
        {
        }

        void IServiceBehavior.AddBindingParameters(ServiceDescription description,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection parameters)
        {
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description,
             ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler;

            try
            {
                errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
            }
            catch (MissingMethodException e)
            {
                throw new ArgumentException(@"The errorHandlerType specified 
                in the ErrorBehaviorAttribute constructor must have a
                public empty constructor.", e);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException(@"The errorHandlerType specified 
                in the ErrorBehaviorAttribute constructor
                must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
            }

            foreach (ChannelDispatcherBase channelDispatcherBase in
            serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher =
                        channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}