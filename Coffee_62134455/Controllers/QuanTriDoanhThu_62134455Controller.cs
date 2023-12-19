using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class QuanTriDoanhThu_62134455Controller : Authen_62134455Controller
    {
        //DbContext_62134455 db = new DbContext_62134455();
        // GET: QuanTriDoanhThu_62134455
        public ActionResult Index(int? Month, int? Year)
        {
            Year = Year ?? DateTime.Now.Year;
            Month = Month ?? DateTime.Now.Month;

            var months = new List<DictionaryObject>();
            var years = new List<DictionaryObject>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(new DictionaryObject() { Value = i, Text = "Tháng " + i });

            }
            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                years.Add(new DictionaryObject() { Value = i, Text = "Năm " + i });
            }
            ViewBag.Months = months;
            ViewBag.Years = years;
            List<DoanhThu> danhthu;
            using (var db = new DbContext_62134455())
            {
                danhthu = db.Database.SqlQuery<DoanhThu>($"SELECT sp.id ,sp.TenSanPham , SUM(ct.SoLuong*ct.DonGia) as TongTien " +
                   "FROM ChiTietDonHangs_62134455 ct join DonHangs_62134455 dh on ct.id_donhang = dh.id join SanPhams_62134455 sp on ct.id_sanpham=sp.id " +
                   "where MONTH(dh.NgayDatHang) = @thang and YEAR(dh.NgayDatHang)= @nam group by sp.TenSanPham, sp.id", new SqlParameter("@thang", Month), new SqlParameter("@nam", Year)).ToList();
            }
            return View(danhthu);
        }
    }
}