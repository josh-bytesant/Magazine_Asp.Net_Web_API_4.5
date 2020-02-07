using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeeService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "Category",
                routeTemplate: "api/categories/{categoryid}",
                defaults: new { controller = "categories", categoryid = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CatArticle",
                routeTemplate: "api/categories/{categoryid}/articles/{id}",
                defaults: new { controller = "catarticle", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Magazine",
                routeTemplate: "api/magazines/{magazineid}",
                defaults: new { controller = "magazines", magazineid = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "MagArticle",
                routeTemplate: "api/magazines/{magazineid}/articles/{id}",
                defaults: new { controller = "magarticle", id = RouteParameter.Optional }
            );
        }
    }
}