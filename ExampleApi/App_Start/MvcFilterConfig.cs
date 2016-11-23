using System.Web;
using System.Web.Mvc;
using Skin.Framework.Web;

namespace ExampleApi
{
    public class MvcFilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
