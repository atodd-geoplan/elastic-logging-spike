using System.ServiceModel;
using System.ServiceModel.Channels;
using Skin.Framework.Wcf.Configuration;

namespace Skin.Framework.Logging.Wcf
{
    [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    public abstract class AbstractService
    {
        protected AbstractService(string applicationName)
        {
            var headers = OperationContext.Current.IncomingMessageProperties["httpRequest"];
            var pi = ((HttpRequestMessageProperty)headers).Headers[ProcessInformationMessageInspector.ProcessInformationHeader];
            ProcessInformation.FromString(pi);
            if (ProcessInformation.Current == null) return;
            ProcessInformation.Current.ApplicationName = applicationName;
            SerilogLogProvider.Instance.Info("{logTag}: requested", LogTags.WcfServiceCall);
        }
    }
}
