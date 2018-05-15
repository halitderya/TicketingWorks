using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ticketing.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { action = "Get", id = RouteParameter.Optional }
);
            config.Routes.MapHttpRoute(
                name: "ApiPutAction",
               routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Put", id = RouteParameter.Optional }
);
            config.Routes.MapHttpRoute(
                name: "ApiPostAction",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Post" }
);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
