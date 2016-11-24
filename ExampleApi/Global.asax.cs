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
        private static readonly string[] Dummies =
        {
            "Rod",
            "Jane",
            "Freddie",
            "Bungle",
            "Zippy",
            "Geoge",
            "Geoffrey"
        };
        private static readonly string[] Envs =
         {
            "skin-preprod",
            "skin-prod",
            "yum-prod",
            "yum-preprod"
        };
        private static readonly string[] Hosts =
         {
            "DEV012",
            "aws001",
            "aws003"
        };
        static readonly Random Randy = new Random();

        private static string RandomUser()
        {
            return Dummies[Randy.Next(Dummies.Length)];
        }

        private static string RandomEnv()
        {
            return Envs[Randy.Next(Envs.Length)];
        }

        private static string RandomHost()
        {
            return Hosts[Randy.Next(Hosts.Length)];
        }

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
            ProcessInformation.Current.user = RandomUser();
            ProcessInformation.Current.env = RandomEnv();
            ProcessInformation.Current.host = RandomHost();

            SerilogLogProvider.Instance.Info("{logTag}: begin: {url}", 
                LogTags.BeginRequest, 
                HttpContext.Current.Request.Url);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            SerilogLogProvider.Instance.Info("{logTag}: started: {startTime:yyyy-MM-dd HH:mm:ss.fff}, ended: {endTime:yyyy-MM-dd HH:mm:ss.fff}",
                LogTags.EndRequest,
                ProcessInformation.Current.GetProcessStartTime(),
                DateTime.UtcNow);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            SerilogLogProvider.Instance.Dispose();
        }
    }
}
