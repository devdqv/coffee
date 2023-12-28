using Coffee.Helper;
using Coffee.Models;
using Coffee.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Coffee.Controllers
{
    public class QuanTriNhanVienController : AuthenController
    {
        DbContextEntity db = new DbContextEntity();
        // GET: QuanTriNhanVien
        public ActionResult Index(int? page, int? pageSize = 20, string search ="")
        {
            if (page == null) page = 1;
            var taikhoans = db.TaiKhoans.Where(x=>x.TenNguoiDung.Contains(search) || x.Username.Contains(search)).ToList();
            ViewBag.search= search;
            return View(taikhoans.ToPagedList(page.Value, pageSize.Value));
        }

        public ActionResult ThemNhanVien()
        {
            ViewBag.VaiTros = new List<DictionaryObject>()
            {
                new DictionaryObject(){Value = (int)VaiTro.NhanVien, Text = "Nhân Viên" },
                new DictionaryObject(){Value = (int)VaiTro.QuanLy, Text = "Quản lý" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult ThemNhanVien(TaiKhoans taikhoan)
        {
            taikhoan.NgayTao =DateTime.Now;
            taikhoan.Password = MD5Tool.MD5Hash(taikhoan.Password);
            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult XoanguoiDung(int id)
        {
            var tk = db.TaiKhoans.FirstOrDefault(x => x.id == id);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return Json(new {message= "Xóa thành công"});
        }


        
    }
}