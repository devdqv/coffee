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
              name: "login",
              url: "login",
              defaults: new { controller = "Login_62134455", action = "FormDangNhap", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "thuc-don",
              url: "thuc-don",
              defaults: new { controller = "Home_62134455", action = "ThucDon", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "nhan-vien",
             url: "nhan-vien",
             defaults: new { controller = "QuanTriNhanVien_62134455", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "thong-tin-san-pham",
             url: "thong-tin-san-pham",
             defaults: new { controller = "SanPham_62134455", action = "ThongTin", id = UrlParameter.Optional }
         );


            routes.MapRoute(
              name: "doanh-thu",
              url: "doanh-thu",
              defaults: new { controller = "QuanTriDoanhThu_62134455", action = "Index", id = UrlParameter.Optional }
          );

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
