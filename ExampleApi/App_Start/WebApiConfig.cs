using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Elmah.Contrib.WebApi;
using Microsoft.Owin.Security.OAuth;
using Skin.Framework.Web;

namespace ExampleApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // log process info footprint on each api in/out
            config.Filters.Add(new ProcessInfoLoggingAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // enable elmah
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

    }
}
