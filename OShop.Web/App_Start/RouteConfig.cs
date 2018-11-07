using System.Web.Mvc;
using System.Web.Routing;

namespace OShopen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Store", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                null, 
                "", 
                new { controller = "Store", action = "Index", Category = (string)null }
            );

            routes.MapRoute(
                null,
                "{Category}", 
                new { controller = "Store", action = "Index" });

            
        }
    }
}
