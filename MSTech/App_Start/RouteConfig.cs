using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSTech
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); //Con ésto soluciono lo expuesto debajo. 
            //routes.MapRoute(
            //    name: "MFile",
            //    url: "MFile/SubirArchivo",
            //    defaults: new {controller = "MFile", action = "SubirArchivo"}   //ACA PODEMOS OBSERVER QUE LA ACCIÓN ES UN STRING, SI MODIFICO EL NOMBRE DEL METODO EN EL CONTROLADOR TENGO QUE VENIR A CAMBIAR ACÁ EL NOMBRE TAMBIEN. ES UN METODO MÁS FRAGIL
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
