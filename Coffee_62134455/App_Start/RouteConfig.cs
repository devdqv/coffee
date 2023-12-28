using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Coffee
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              name: "login",
              url: "login",
              defaults: new { controller = "Login", action = "FormDangNhap", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "thuc-don",
              url: "thuc-don",
              defaults: new { controller = "Home", action = "ThucDon", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "nhan-vien",
             url: "nhan-vien",
             defaults: new { controller = "QuanTriNhanVien", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "thong-tin-san-pham",
             url: "thong-tin-san-pham",
             defaults: new { controller = "SanPham", action = "ThongTin", id = UrlParameter.Optional }
         );


            routes.MapRoute(
              name: "doanh-thu",
              url: "doanh-thu",
              defaults: new { controller = "QuanTriDoanhThu", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "danh-sach-don-hang",
               url: "danh-sach-don-hang",
               defaults: new { controller = "QuanTriDonHang", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "danh-sach-sp",
               url: "danh-sach-sp",
               defaults: new { controller = "QuanTriSP", action = "DanhSachSanPham", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "cap-nhat-sp",
               url: "cap-nhat-sp",
               defaults: new { controller = "QuanTriSP", action = "ThemSanPham", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




        }
    }
}
