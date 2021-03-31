using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace facturacion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
        
            // Rutas de API web

            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute(origins: "http://localhost:4200", headers: "*", methods: "*") { SupportsCredentials = true });
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
           = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }
    }
}
