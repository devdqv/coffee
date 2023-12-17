using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Coffee_62134455
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "danh-sach-don-hang",
               url: "danh-sach-don-hang",
               defaults: new { controller = "QuanTriDonHang_62134455", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "danh-sach-sp",
               url: "danh-sach-sp",
               defaults: new { controller = "QuanTriSP_62134455", action = "DanhSachSanPham", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "cap-nhat-sp",
               url: "cap-nhat-sp",
               defaults: new { controller = "QuanTriSP_62134455", action = "ThemSanPham", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home_62134455", action = "Index", id = UrlParameter.Optional }
            );

           


        }
    }
}
