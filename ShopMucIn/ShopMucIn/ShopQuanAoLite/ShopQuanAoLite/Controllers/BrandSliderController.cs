using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;
namespace ShopQuanAoLite.Controllers
{
    public class BrandSliderController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: BrandList
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DanhMuc(int id)
        {
            var danhmuc = from cd in data.SanPhams
                          where cd.MaH == id
                          select cd;

            return PartialView(danhmuc);
        }
        public PartialViewResult BrandList()
        {
            var hang = (from cd in data.Hangs select cd).ToList();
            return PartialView(hang);
        }
    }
}