using System.Web.Http;
using System.Web.Http.Dependencies;

namespace ApiTest.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IDependencyResolver Resolver
        {
            get { return RequestContext.Configuration.DependencyResolver; }
        }
    }
}