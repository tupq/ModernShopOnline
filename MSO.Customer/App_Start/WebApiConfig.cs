using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MSO.Customer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // To use swagger
            if (bool.Parse(ConfigurationManager.AppSettings.Get("EnabledSwagger")))
            {
                var corsAttr = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(corsAttr);
            }

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "cm/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
