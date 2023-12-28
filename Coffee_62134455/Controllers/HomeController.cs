using Coffee.Models;
using Coffee.Models.DtoEdit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class HomeController : Controller
    {
        DbContextEntity db = new DbContextEntity();
        [ChildActionOnly]
        public ActionResult NavBar()
        {
            var donhang = Session["donhang"] as DonHangsDtoEdit;
            int total = 0;
            if (donhang != null)
            {
                total = donhang.ChiTietDonHangsDtoEdit.Count;
            }
            return PartialView("_NavBar", total);
        }

        public ActionResult Index()
        {
            //Lấy ra 4 sản phẩm bán chạy nhất
            ViewBag.SPBanChayNhat = db.SanPhams.Take(4).ToList();
            var danhMucs = db.DanhMucs.OrderBy(x => x.TenDanhMuc).ToList();
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
            List<SanPhams> listSanPham;

            listSanPham = db.SanPhams.Where(x => x.id_danhmuc == id_danhmuc).Take(4).ToList();

            return View(listSanPham);
        }

        public ActionResult ThucDon()
        {


            ViewBag.listDanhMuc = db.DanhMucs.ToList();
            ViewBag.listSanPham = db.SanPhams.ToList();


            return View();
        }

        public ActionResult PopupDatMon(int id)
        {
            SanPhams sp;

            sp = db.SanPhams.FirstOrDefault(x => x.id == id);

            return View(sp);
        }

        [HttpPost]
        public ActionResult ThemVaoGio(ChiTietDonHangsDtoEdit model)
        {
            try
            {

                //Lấy ra sp ứng với sp Khách hàng đặt
                SanPhams sp;

                sp = db.SanPhams.FirstOrDefault(x => x.id == model.id_sanpham);
                model.DonGia = sp.Gia;
                model.TenSanPham = sp.TenSanPham;
                model.MoTa = sp.MoTa;
                model.HinhAnh = sp.HinhAnh;

                //Nếu là sản phẩm thêm vào giỏ đầu tiên
                if (Session["donhang"] == null)
                {
                    var donhang = new DonHangsDtoEdit();
                    donhang.ChiTietDonHangsDtoEdit.Add(model);
                    Session["donhang"] = donhang;
                }
                else
                {
                    //Nếu đã có sản phẩm trong giỏ hàng rồi
                    var donhang = Session["donhang"] as DonHangsDtoEdit;
                    var matHangTrongGio = donhang.ChiTietDonHangsDtoEdit.FirstOrDefault(x => x.id_sanpham == model.id_sanpham && x.Size == model.Size);
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
                        donhang.ChiTietDonHangsDtoEdit.Add(model);
                    }
                    Session["donhang"] = donhang;
                }
                return Json(new { status = 1, message = "Đã thêm sản phẩm này vào giỏ", total = (Session["donhang"] as DonHangsDtoEdit).ChiTietDonHangsDtoEdit.Count });
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, message = ex.Message });
            }
        }




    }
}