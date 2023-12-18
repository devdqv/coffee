using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class GioHang_62134455Controller : Controller
    {
        // GET: GioHang_62134455
        public ActionResult Index()
        {
            var donhang = new DonHangsDtoEdit_62134455();
            if (Session["donhang"] != null)
            {
                donhang = Session["donhang"] as DonHangsDtoEdit_62134455;
            }
            return View(donhang);
        }

        [HttpPost]
        public ActionResult CapNhatSanPhamTrongGio(ChiTietDonHangsDtoEdit_62134455 item)
        {
            var donhang = new DonHangsDtoEdit_62134455();
            decimal? ThanhTien = 0;
            if (Session["donhang"] != null)
            {
                donhang = Session["donhang"] as DonHangsDtoEdit_62134455;
                var itemDb = donhang.ChiTietDonHangsDtoEdit_62134455.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                if (item.actionEdit == "remove")
                {
                    donhang.ChiTietDonHangsDtoEdit_62134455.Remove(itemDb);
                }
                else if(item.actionEdit == "changeQuantity")
                {
                    var chitietDH = donhang.ChiTietDonHangsDtoEdit_62134455.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                    chitietDH.SoLuong = item.SoLuong;
                    ThanhTien = (item.SoLuong * itemDb.DonGia);
                }
                else if (item.actionEdit == "changeNote")
                {
                    var chitietDH = donhang.ChiTietDonHangsDtoEdit_62134455.FirstOrDefault(x => x.id_sanpham == item.id_sanpham);
                    chitietDH.GhiChu = item.GhiChu;
                }
                Session["donhang"] = donhang;
                var tongtienS = donhang.ChiTietDonHangsDtoEdit_62134455.Sum(x => x.DonGia * x.SoLuong);
                var phivanchuyenS = tongtienS == 0 ? 0 : tongtienS > 300000 ? 0 : 30000;
                return Json(new { tongtien = string.Format("{0:#,###} ₫", tongtienS), 
                    phivanchuyen = (tongtienS != 0 && phivanchuyenS == 0)? "Miễn phí":string.Format("{0:#,###} ₫", phivanchuyenS), 
                    sotienphaitra = string.Format("{0:#,###} ₫", tongtienS + phivanchuyenS),
                    thanhtien= string.Format("{0:#,###} ₫", ThanhTien),
                    total = donhang.ChiTietDonHangsDtoEdit_62134455.Count
                });
            }
            else
            {
                return Json(new { message = "Giỏ hàng không tồn tại" });
            }
        }


        [HttpPost]
        public ActionResult DatHang(DonHangsDtoEdit_62134455 data)
        {
            var donhangDb = new DonHangs_62134455();
            
            if (Session["donhang"] != null)
            {
                var donhang = Session["donhang"] as DonHangsDtoEdit_62134455;
                donhangDb.NgayDatHang = DateTime.Now;
                donhangDb.TrangThai = 0; //0 là đơn hàng vừa đặt và nhân viên chưa xác nhận
                donhangDb.DiaChiNhanHang = data.DiaChiNhanHang;
                donhangDb.SDT = data.SDT;
                donhangDb.TenKhachHang = data.TenKhachHang;
                foreach (var item in donhang.ChiTietDonHangsDtoEdit_62134455)
                {
                    ChiTietDonHangs_62134455 itemDb = JsonConvert.DeserializeObject<ChiTietDonHangs_62134455>(JsonConvert.SerializeObject(item));
                    donhangDb.ChiTietDonHangs_62134455.Add(itemDb);
                }
                using(var db = new DbContext_62134455())
                {
                    db.DonHangs_62134455.Add(donhangDb);
                    db.SaveChanges();
                    Session["donhang"] = null;
                }    
                    
            }
            else
            {
                return Json(new { status = -1, message = "Bạn cần chọn sản phẩm vào giỏ hàng trước khi mua" });
            }

            return Json(new { status = 1, message = "Đơn của bạn đã được đặt, nhân viên cửa hàng sẽ liên hệ với bạn trong ít phút" });
        }
    }
}