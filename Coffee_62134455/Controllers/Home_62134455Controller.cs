using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class Home_62134455Controller : Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        [ChildActionOnly]
        public ActionResult NavBar()
        {
            var donhang = Session["donhang"] as DonHangsDtoEdit_62134455;
            int total = 0;
            if (donhang != null)
            {
                total = donhang.ChiTietDonHangsDtoEdit_62134455.Count;
            }
            return PartialView("_NavBar", total);
        }

        public ActionResult Index()
        {
            //Lấy ra 4 sản phẩm bán chạy nhất
            ViewBag.SPBanChayNhat = db.SanPhams_62134455.Include(x => x.DanhMucs_62134455).Take(4).ToList();
            var danhMucs = db.DanhMucs_62134455.OrderBy(x => x.TenDanhMuc).ToList();
            ViewBag.DanhMucSP = danhMucs;
            ViewBag.FirstDanhMuc = danhMucs.FirstOrDefault();

            return View();
        }

        /// <summary>
        /// Lấy Sản phẩm theo từng danh mục khi khách hàng kích ở trang chủ, lấy 4 cái 1 lần
        /// </summary>
        /// <param name="id_danhmuc"></param>
        /// <returns></returns>
        public ActionResult SanPhamTheoDanhMuc(int? id_danhmuc)
        {
            List<SanPhams_62134455> listSanPham;

            listSanPham = db.SanPhams_62134455.Where(x => x.id_danhmuc == id_danhmuc).Take(4).ToList();

            return View(listSanPham);
        }

        public ActionResult ThucDon()
        {


            ViewBag.listDanhMuc = db.DanhMucs_62134455.ToList();
            ViewBag.listSanPham = db.SanPhams_62134455.ToList();


            return View();
        }

        public ActionResult PopupDatMon(int id)
        {
            SanPhams_62134455 sp;

            sp = db.SanPhams_62134455.FirstOrDefault(x => x.id == id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult ThemVaoGio(ChiTietDonHangsDtoEdit_62134455 model)
        {
            try
            {

                //Lấy ra sp ứng với sp Khách hàng đặt
                SanPhams_62134455 sp;

                sp = db.SanPhams_62134455.FirstOrDefault(x => x.id == model.id_sanpham);
                model.DonGia = sp.Gia;
                model.TenSanPham = sp.TenSanPham;
                model.TenSanPham = sp.MoTa;
                model.HinhAnh = sp.HinhAnh;

                //Nếu là sản phẩm thêm vào giỏ đầu tiên
                if (Session["donhang"] == null)
                {
                    var donhang = new DonHangsDtoEdit_62134455();
                    donhang.ChiTietDonHangsDtoEdit_62134455.Add(model);
                    Session["donhang"] = donhang;
                }
                else
                {
                    //Nếu đã có sản phẩm trong giỏ hàng rồi
                    var donhang = Session["donhang"] as DonHangsDtoEdit_62134455;
                    var matHangTrongGio = donhang.ChiTietDonHangsDtoEdit_62134455.FirstOrDefault(x => x.id_sanpham == model.id_sanpham && x.Size == model.Size);
                    //Nếu mặt hàng này đã có trong giỏ => cập nhật số lượng
                    if (matHangTrongGio != null)
                    {
                        matHangTrongGio.SoLuong += model.SoLuong;
                        if (!string.IsNullOrEmpty(model.GhiChu))
                        {
                            matHangTrongGio.GhiChu = model.GhiChu;
                        }
                    }
                    else
                    {
                        donhang.ChiTietDonHangsDtoEdit_62134455.Add(model);
                    }
                    Session["donhang"] = donhang;
                }
                return Json(new { status = 1, message = "Đã thêm sản phẩm này vào giỏ", total = (Session["donhang"] as DonHangsDtoEdit_62134455).ChiTietDonHangsDtoEdit_62134455.Count });
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, message = ex.Message });
            }
        }




    }
}