using Coffee_62134455.Helper;
using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Coffee_62134455.Controllers
{
    public class QuanTriNhanVien_62134455Controller : Authen_62134455Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        // GET: QuanTriNhanVien_62134455
        public ActionResult Index(int? page, int? pageSize = 20)
        {
            if (page == null) page = 1;
            var taikhoans = db.TaiKhoans_62134455.ToList();
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
        public ActionResult ThemNhanVien(TaiKhoans_62134455 taikhoan)
        {
            taikhoan.NgayTao =DateTime.Now;
            taikhoan.Password = MD5Tool.MD5Hash(taikhoan.Password);
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