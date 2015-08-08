﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyPlace.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // these routes need to be defined before the attribute routes get defined-- Probably can do it via attribute routing
            //Below 2 routes for the SPA silo
            routes.MapRoute(
                name: "accountRegisterRoot",
                url: "account/register",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                name: "accountRegister",
                url: "account/register/{*catchall}",
                defaults: new { controller = "Account", action = "Register" });


            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
