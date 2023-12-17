using Coffee_62134455.Models;
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
        public ActionResult Index()
        {
            using (var db = new DbContext_62134455())
            {
                //Lấy ra 4 sản phẩm bán chạy nhất
                ViewBag.SPBanChayNhat = db.SanPhams_62134455.Take(4).Include(x => x.DanhMucs_62134455).ToList();
                var danhMucs = db.DanhMucs_62134455.OrderBy(x=>x.TenDanhMuc).ToList();
                ViewBag.DanhMucSP = danhMucs;
                ViewBag.FirstDanhMuc = danhMucs.FirstOrDefault();
            }    
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
            using (var db = new DbContext_62134455())
            {
                listSanPham = db.SanPhams_62134455.Take(4).Where(x => x.id_danhmuc == id_danhmuc).ToList();
            }
            return View(listSanPham);
        }

        public ActionResult ThucDon()
        {
            
            using (var db = new DbContext_62134455())
            {
                ViewBag.listDanhMuc = db.DanhMucs_62134455.ToList();
                ViewBag.listSanPham = db.SanPhams_62134455.ToList();
            }
            
            return View();
        }

        public ActionResult PopupDatMon()
        {
            return View();
        }




    }
}