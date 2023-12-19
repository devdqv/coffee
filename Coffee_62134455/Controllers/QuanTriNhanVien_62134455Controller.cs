using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class QuanTriNhanVien_62134455Controller : Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        // GET: QuanTriNhanVien_62134455
        public ActionResult Index()
        {
            var taikhoans = db.TaiKhoans_62134455.ToList();
            return View(taikhoans);
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
        public ActionResult ThemNhanVien(TaiKhoans_62134455 taikhoan)
        {
            taikhoan.NgayTao =DateTime.Now; 
            db.TaiKhoans_62134455.Add(taikhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult XoanguoiDung(int id)
        {
            var tk = db.TaiKhoans_62134455.FirstOrDefault(x => x.id == id);
            db.TaiKhoans_62134455.Remove(tk);
            db.SaveChanges();
            return Json(new {message= "Xóa thành công"});
        }


        
    }
}