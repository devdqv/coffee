using Coffee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;

namespace Coffee.Controllers
{
    public class QuanTriSPController : AuthenController
    {
        DbContextEntity db = new DbContextEntity();
        // GET: QuanTriSP
        public ActionResult DanhSachSanPham(int? page, int? pageSize = 20, string search = "")
        {

            if (page == null) page = 1;
            var lstSP = db.SanPhams.Where(x=>x.TenSanPham.Contains(search)).ToList();
            ViewBag.search = search;

            return View(lstSP.ToPagedList(page.Value, pageSize.Value));

        }

        public ActionResult ThemSanPham(int? id)
        {
            SanPhams sp;
            if (id != null)
            {

                //Mode sửa thì có id truyền vào
                sp = db.SanPhams.FirstOrDefault(x => x.id == id);
            }
            else
            {
                sp = new SanPhams();
            }
            ViewBag.DanhMucs = db.DanhMucs.ToList();


            return View(sp);
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {

            var obj = db.SanPhams.FirstOrDefault(x => x.id == id);
            if (obj != null)
            {
                db.SanPhams.Remove(obj);
                db.SaveChanges();
            }

            return Json(new { status = 1, message = "Đã xóa sản phẩm thành công !" });
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ThemSanPham(SanPhams sanPham)
        {
            string fileNameTemp = ""; //Tên file ảnh nếu có
            //xử lý upload ảnh
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HinhAnh"];
                string filename = Path.GetFileNameWithoutExtension(pic.FileName);
                filename = filename.Replace(" ", "");
                string extension = Path.GetExtension(pic.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                fileNameTemp = filename;
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
            }


            //Cập nhật 
            if (sanPham.id != 0)
            {
                var spUpdate = db.SanPhams.FirstOrDefault(x => x.id == sanPham.id);
                spUpdate.TenSanPham = sanPham.TenSanPham;
                spUpdate.Gia = sanPham.Gia;
                spUpdate.GhiChu = sanPham.GhiChu;
                spUpdate.Size = sanPham.Size;
                spUpdate.MoTa = sanPham.MoTa;
                spUpdate.id_danhmuc = sanPham.id_danhmuc;
                //Nếu có ảnh up mới thì cập nhật lại ảnh
                if (!string.IsNullOrEmpty(fileNameTemp))
                {
                    spUpdate.HinhAnh = fileNameTemp;
                }
            }
            else
            {
                sanPham.HinhAnh = fileNameTemp;
                db.SanPhams.Add(sanPham);
            }

            db.SaveChanges();



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
        public ActionResult ThemDanhMuc(DanhMucs danhmuc)
        {

            db.DanhMucs.Add(danhmuc);
            db.SaveChanges();

            return Json(new { status = 1, message = "Thêm mới danh mục thành công !", data = danhmuc });
        }


    }
}