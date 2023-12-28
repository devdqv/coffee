using Coffee.Models;
using Coffee.Models.DtoEdit;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class SanPhamController : Controller
    {
        DbContextEntity db = new DbContextEntity();
        // GET: SanPham
        public ActionResult ThongTin(int id)
        {
            var sanpham = db.SanPhams.FirstOrDefault(x => x.id == id);
            var sizeArr = sanpham.Size.Split(';');
            List<DictionaryObject> sizes = new List<DictionaryObject>();
            for(int i = 0;i<sizeArr.Length -1;i++)
            {
                sizes.Add(new DictionaryObject() { Text = sizeArr[i] });
            }
            ViewBag.Sizes = sizes;
            return View(sanpham);
        }
    }
}