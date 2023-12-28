using Coffee.Models;
using Coffee.Models.DtoEdit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class GioHangController : Controller
    {

        DbContextEntity db = new DbContextEntity();
        // GET: GioHang
        public ActionResult Index()
        {
            var donhang = new DonHangsDtoEdit();
            if (Session["donhang"] != null)
            {
                donhang = Session["donhang"] as DonHangsDtoEdit;
            }
            return View(donhang);
        }

        [HttpPost]
        public ActionResult CapNhatSanPhamTrongGio(ChiTietDonHangsDtoEdit item)
        {
            var donhang = new DonHangsDtoEdit();
            decimal? ThanhTien = 0;
            if (Session["donhang"] != null)
            {
                donhang = Session["donhang"] as DonHangsDtoEdit;
                var itemDb = donhang.ChiTietDonHangsDtoEdit.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                if (item.actionEdit == "remove")
                {
                    donhang.ChiTietDonHangsDtoEdit.Remove(itemDb);
                }
                else if (item.actionEdit == "changeQuantity")
                {
                    var chitietDH = donhang.ChiTietDonHangsDtoEdit.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                    chitietDH.SoLuong = item.SoLuong;
                    ThanhTien = (item.SoLuong * itemDb.DonGia);
                }
                else if (item.actionEdit == "changeNote")
                {
                    var chitietDH = donhang.ChiTietDonHangsDtoEdit.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                    chitietDH.GhiChu = item.GhiChu;
                }
                Session["donhang"] = donhang;
                var tongtienS = donhang.ChiTietDonHangsDtoEdit.Sum(x => x.DonGia * x.SoLuong);
                var phivanchuyenS = tongtienS == 0 ? 0 : tongtienS > 300000 ? 0 : 30000;
                return Json(new
                {
                    tongtien = string.Format("{0:#,###} ₫", tongtienS),
                    phivanchuyen = (tongtienS != 0 && phivanchuyenS == 0) ? "Miễn phí" : string.Format("{0:#,###} ₫", phivanchuyenS),
                    sotienphaitra = string.Format("{0:#,###} ₫", tongtienS + phivanchuyenS),
                    thanhtien = string.Format("{0:#,###} ₫", ThanhTien),
                    total = donhang.ChiTietDonHangsDtoEdit.Count
                });
            }
            else
            {
                return Json(new { message = "Giỏ hàng không tồn tại" });
            }
        }


        [HttpPost]
        public ActionResult DatHang(DonHangsDtoEdit data)
        {
            var donhangDb = new DonHangs();

            if (Session["donhang"] != null)
            {
                var donhang = Session["donhang"] as DonHangsDtoEdit;
                donhangDb.NgayDatHang = DateTime.Now;
                donhangDb.TrangThai = 0; //0 là đơn hàng vừa đặt và nhân viên chưa xác nhận
                donhangDb.DiaChiNhanHang = data.DiaChiNhanHang;
                donhangDb.SDT = data.SDT;
                donhangDb.TenKhachHang = data.TenKhachHang;
                donhangDb.GhiChu = data.GhiChuDonHang;
                foreach (var item in donhang.ChiTietDonHangsDtoEdit)
                {
                    ChiTietDonHangs itemDb = JsonConvert.DeserializeObject<ChiTietDonHangs>(JsonConvert.SerializeObject(item));
                    donhangDb.ChiTietDonHangs.Add(itemDb);
                }

                db.DonHangs.Add(donhangDb);
                db.SaveChanges();

                Session["donhang"] = null;

            }
            else
            {
                return Json(new { status = -1, message = "Bạn cần chọn sản phẩm vào giỏ hàng trước khi mua" });
            }

            return Json(new { status = 1, message = "Đơn của bạn đã được đặt, nhân viên cửa hàng sẽ liên hệ với bạn trong ít phút" });
        }
    }
}