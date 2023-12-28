using Coffee.Helper;
using Coffee.Models;
using Coffee.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class LoginController : Controller
    {
        DbContextEntity db = new DbContextEntity();
        // GET: Login
        [HttpGet]
        public ActionResult FormDangNhap()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(TaiKhoans userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
            {
                ModelState.AddModelError("","Không được bỏ trống tên đăng nhập hoặc mật khẩu");
                return View("FormDangNhap",userLogin);  
            }
            var userPass = MD5Tool.MD5Hash(userLogin.Password);
            var user = db.TaiKhoans.FirstOrDefault(x => x.Username == userLogin.Username && userPass == x.Password);
            //Đăng nhập thành công
            if (user != null)
            {
                Session["user"] = user;
                if (user.VaiTro == (int)VaiTro.NhanVien)
                {
                    return RedirectToAction("Index", "QuanTriDonHang");
                }
                else
                {

                return RedirectToAction("DanhSachSanPham", "QuanTriSP");
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