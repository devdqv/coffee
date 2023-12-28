using Coffee.Models;
using Coffee.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class QuanTriDoanhThuController : AuthenController
    {
        DbContextEntity db = new DbContextEntity();
        // GET: QuanTriDoanhThu
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

            //Lấy doanh thu
            danhthu = db.Database.SqlQuery<DoanhThu>($"SELECT sp.id ,sp.TenSanPham , SUM(ct.SoLuong*ct.DonGia) as TongTien " +
               "FROM ChiTietDonHangs ct join DonHangs dh on ct.id_donhang = dh.id join SanPhams sp on ct.id_sanpham=sp.id " +
               "where MONTH(dh.NgayDatHang) = @thang and YEAR(dh.NgayDatHang)= @nam group by sp.TenSanPham, sp.id", new SqlParameter("@thang", Month), new SqlParameter("@nam", Year)).ToList();

            return View(danhthu);
        }
    }
}