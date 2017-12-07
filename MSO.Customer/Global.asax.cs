using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NSwag.AspNet.Owin;

namespace MSO.Customer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (bool.Parse(ConfigurationManager.AppSettings.Get("EnabledSwagger")))
            {
                RouteTable.Routes.MapOwinPath("swagger", app =>
                {
                    app.UseSwaggerUi(typeof(WebApiApplication).Assembly, new SwaggerUiSettings
                    {
                        MiddlewareBasePath = "/swagger",
                        DefaultUrlTemplate = "api/{controller}/{action}/{id}"
                    });
                });
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
