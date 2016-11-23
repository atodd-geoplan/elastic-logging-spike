using System;
using System.Web.Http;

namespace ExampleApi.Controllers
{
    [RoutePrefix("api/throw")]
    public class ThrowController : ApiController
    {
        [Route("apierror")]
        [HttpGet]
        public string ApiError()
        {
            throw new InvalidOperationException("This API route is currently unsupported");
        }

        [Route("wcferror")]
        [HttpGet]
        public void WcfError()
        {
            ServiceReference1.Service1Client client = new
                ServiceReference1.Service1Client();
            client.ThrowError();
        }
    }
}