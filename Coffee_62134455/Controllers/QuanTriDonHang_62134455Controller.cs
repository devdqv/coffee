using Coffee_62134455.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class QuanTriDonHang_62134455Controller : Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        // GET: QuanTriDonHang_62134455
        public ActionResult Index()
        {
            List<DonHangs_62134455> donHangs = null;

            donHangs = db.DonHangs_62134455.Where(x => x.TrangThai == 0).ToList();

            return View(donHangs);
        }

        // GET: QuanTriDonHang_62134455
        public ActionResult ChiTietDonHang(int id)
        {
            var donHang = db.DonHangs_62134455.FirstOrDefault(x => x.id == id);

            return View(donHang);
        }

        [HttpPost]
        public ActionResult XacNhanDonHang(int? id)
        {
            var donHang = db.DonHangs_62134455.FirstOrDefault(x => x.id == id);
            donHang.TrangThai = 1; //Đã xác nhận
            db.SaveChanges();
            return View("ChiTietDonHang", donHang);
        }
    }
}