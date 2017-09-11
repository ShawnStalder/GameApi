using System.Web.Http;
using System.Web.Mvc;

namespace ApiTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            GlobalConfiguration.Configure(WebApiConfig.Register);

            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
