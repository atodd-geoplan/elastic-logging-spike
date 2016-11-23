using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Skin.Framework.Logging;

namespace ExampleApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MvcFilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ProcessInformation.New("ExampleApi");
            SerilogLogProvider.Instance.Info("{logTag}: begin: {url}", 
                LogTags.RequestInfo, 
                HttpContext.Current.Request.Url);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            SerilogLogProvider.Instance.Info("{logTag}: started: {startTime}, ended: {endTime}",
                LogTags.RequestInfo,
                ProcessInformation.Current.GetProcessStartTime(),
                DateTime.UtcNow);
        }
    }
}
