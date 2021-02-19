using Fansoft.ConsultaClima.Core.Contracts;
using Fansoft.ConsultaClima.Core.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace Fansoft.ConsultaClima.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(
                    new UnityContainer().RegisterType<IPrevisaoTempoService, PrevisaoTempoService>()
                ));


            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.MapMvcAttributeRoutes();
        }
    }
}
