using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cartt", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Pay",
                url: "thanh-toan",
                defaults: new { controller = "Cartt", action = "Pay", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "tao-tai-khoan",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Detail",
                url: "chi-tiet/{metaTitle}-{id}",
                defaults: new { controller = "Detail", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Home",
                url: "trang-chu/{action}/{id}",
                defaults: new { controller = "Homei", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-Category",
                url: "the-loai/{metaTitle}-{IDCategory}",
                defaults: new { controller = "ProductCategory", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "ProductCategory", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-PublisingCompany",
                url: "nha-xuat-ban/{metaTitle}-{IDPublisingCompany}",
                defaults: new { controller = "ProductCategory", action = "IDPublisingCompany", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-Author",
                url: "tac-gia/{metaTitle}-{IDAuthor}",
                defaults: new { controller = "ProductCategory", action = "IDAuthor", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-BestSeller",
                url: "ban-chay/{action}/{id}",
                defaults: new { controller = "ProductCategory", action = "BestSeller", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-Sale",
                url: "giam-gia/{action}/{id}",
                defaults: new { controller = "ProductCategory", action = "Sale", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Filter-New",
                url: "moi-ra-mat/{action}/{id}",
                defaults: new { controller = "ProductCategory", action = "New", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Homei", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
