using Coffee_62134455.Models;
using Coffee_62134455.Models.DtoEdit;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class SanPham_62134455Controller : Controller
    {
        DbContext_62134455 db = new DbContext_62134455();
        // GET: SanPham_62134455
        public ActionResult ThongTin(int id)
        {
            var sanpham = db.SanPhams_62134455.FirstOrDefault(x => x.id == id);
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