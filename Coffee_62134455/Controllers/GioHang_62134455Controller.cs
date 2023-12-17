using Coffee_62134455.Models;
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
            var donhang = new DonHangs_62134455();
            if (Session["donhang"] != null)
            {
                donhang = Session["donhang"] as DonHangs_62134455;
            }
            return View(donhang);
        }

        public ActionResult ThanhToan()
        {
            return View();
        }
    }
}