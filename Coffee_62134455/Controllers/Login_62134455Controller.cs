using Coffee_62134455.Helper;
using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class Login_62134455Controller : Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        // GET: Login_62134455
        [HttpGet]
        public ActionResult FormDangNhap()
        {
            return View();
        }

        // GET: Login_62134455
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(TaiKhoans_62134455 userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
            {
                ModelState.AddModelError("","Không được bỏ trống tên đăng nhập hoặc mật khẩu");
                return View("FormDangNhap",userLogin);  
            }
            var userPass = MD5Tool.MD5Hash(userLogin.Password);
            var user = db.TaiKhoans_62134455.FirstOrDefault(x => x.Username == userLogin.Username && userPass == x.Password);
            //Đăng nhập thành công
            if (user != null)
            {
                Session["user"] = user;
                if (user.VaiTro == (int)VaiTro.NhanVien)
                {
                    return RedirectToAction("Index", "QuanTriDonHang_62134455");
                }
                else
                {

                return RedirectToAction("DanhSachSanPham", "QuanTriSP_62134455");
                }
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
            return View("FormDangNhap", userLogin);
        }

        public ActionResult DangXuat() {
            Session["user"] = null;
            return RedirectToAction("FormDangNhap");
        }
    }
}