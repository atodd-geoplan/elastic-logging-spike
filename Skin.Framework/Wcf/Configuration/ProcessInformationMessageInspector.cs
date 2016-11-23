using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Newtonsoft.Json;
using Skin.Framework.Logging;

namespace Skin.Framework.Wcf.Configuration
{
    public class ProcessInformationMessageInspector : IClientMessageInspector
    {
        public const string ProcessInformationHeader = "ProcessInformation";

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request,
            System.ServiceModel.IClientChannel channel)
        {
            var pi = JsonConvert.SerializeObject(ProcessInformation.Current);
            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                if (string.IsNullOrEmpty(httpRequestMessage.Headers[ProcessInformationHeader]))
                {
                    httpRequestMessage.Headers[ProcessInformationHeader] = pi;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add(ProcessInformationHeader, pi);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }


    }

    public class ProcessInformationEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ProcessInformationMessageInspector inspector = new ProcessInformationMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

    }

    public class ProcessInformationBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(ProcessInformationEndpointBehavior);

        protected override object CreateBehavior()
        {
            return new ProcessInformationEndpointBehavior();
        }
    }
}
