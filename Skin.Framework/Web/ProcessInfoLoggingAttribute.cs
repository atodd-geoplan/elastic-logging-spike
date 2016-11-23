using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Skin.Framework.Logging;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace Skin.Framework.Web
{
    public class ProcessInfoLoggingAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            SerilogLogProvider.Instance.Info("{logTag}: start: {controller}/{action}", 
                LogTags.ApiCall,
                context.ActionDescriptor.ControllerDescriptor.ControllerName, 
                context.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            SerilogLogProvider.Instance.Info("{logTag}: executed: {controller}/{action}", 
                LogTags.ApiCall,
                context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                context.ActionContext.ActionDescriptor.ActionName);
        }
    }
}
