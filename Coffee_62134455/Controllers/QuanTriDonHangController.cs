using Coffee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Coffee.Controllers
{
    public class QuanTriDonHangController : AuthenController
    {
        DbContextEntity db = new DbContextEntity();
        // GET: QuanTriDonHang
        public ActionResult Index(int? page, int? pageSize = 10)
        {
            List<DonHangs> donHangs = null;
            if (page == null) page = 1;
            donHangs = db.DonHangs.Where(x => x.TrangThai == 0).ToList();

            return View(donHangs.ToPagedList(page.Value, pageSize.Value));
        }

        // GET: QuanTriDonHang
        public ActionResult ChiTietDonHang(int id)
        {
            var donHang = db.DonHangs.FirstOrDefault(x => x.id == id);

            return View(donHang);
        }

        [HttpPost]
        public ActionResult XacNhanDonHang(int? id)
        {
            var donHang = db.DonHangs.FirstOrDefault(x => x.id == id);
            donHang.TrangThai = 1; //Đã xác nhận
            db.SaveChanges();
            return View("ChiTietDonHang", donHang);
        }
    }
}