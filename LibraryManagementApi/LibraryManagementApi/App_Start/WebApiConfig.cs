using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryManagementApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS for all domains, all headers, and all methods. 
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API configuration and services
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remove XML format globally, if not needed.
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
