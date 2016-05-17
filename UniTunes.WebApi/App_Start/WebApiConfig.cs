using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace UniTunesApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Specific",
               routeTemplate: "{controller}/{id}/{action}",
               defaults: null,
               constraints: new { id = @"\d+", action = @"\w+" }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApiGet",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPut",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Put" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPost",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiDelete",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

        }
    }
}
