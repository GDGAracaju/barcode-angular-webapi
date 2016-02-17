using System.Web.Http;
using WebAPI.Backend.App_Start;

namespace WebAPI.Backend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.RegisterDependencyInjection();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
