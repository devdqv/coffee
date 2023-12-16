using Coffee_62134455.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Coffee_62134455.Controllers
{
    public class QuanTriSP_62134455Controller : Controller
    {
        // GET: QuanTriSP_62134455
        public ActionResult DanhSachSanPham()
        {
            using (var db = new DbContext_62134455())
            {

                var lstSP = db.SanPhams_62134455.Include(x=>x.DanhMucs_62134455).ToList();
                
                return View(lstSP);
            }
        }

        public ActionResult ThemSanPham()
        {
            using (var db = new DbContext_62134455())
            {
                ViewBag.DanhMucs = db.DanhMucs_62134455.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            using (var db = new DbContext_62134455())
            {
                var obj = db.SanPhams_62134455.FirstOrDefault(x => x.id == id);
                if (obj != null)
                {
                    db.SanPhams_62134455.Remove(obj);
                    db.SaveChanges();
                }    
            }
            return Json(new { status = 1, message = "Đã xóa sản phẩm thành công !"});
        }

        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ThemSanPham(SanPhams_62134455 sanPham)
        {

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HinhAnh"];
                string filename = Path.GetFileNameWithoutExtension(pic.FileName);
                filename = filename.Replace(" ", "");
                string extension = Path.GetExtension(pic.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                var fileNameTemp = filename;
                var path = "~/Assets/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Assets/images/"), filename);

                // Saving Image in Original Mode
                pic.SaveAs(filename);

                // resizing image
                MemoryStream ms = new MemoryStream();
                WebImage img = new WebImage(filename);
                // end resize
                if (img.Width > 1200 || img.Height > 1200)
                    img.Resize(1200, 1200, true, false);
                img.Save(filename);
                using (var db = new DbContext_62134455())
                {
                    sanPham.HinhAnh = fileNameTemp;
                    db.SanPhams_62134455.Add(sanPham);
                    db.SaveChanges();
                }

            }

            
            return Json(new { status = 1, message = "Thêm mới sản phẩm thành công !", data = sanPham });
        }

        /// <summary>
        /// GET giao diện
        /// </summary>
        /// <returns></returns>
        public ActionResult ThemDanhMuc()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ThemDanhMuc(DanhMucs_62134455 danhmuc)
        {   
            using (var db = new DbContext_62134455())
            {
                db.DanhMucs_62134455.Add(danhmuc);
                db.SaveChanges();
            }    
            return Json(new {status = 1, message = "Thêm mới danh mục thành công !", data = danhmuc});
        }


    }
}