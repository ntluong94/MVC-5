using PagedList;
using ShopQuanAoLite.Models;
using ShopQuanAoLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Controllers
{
    public class HomeController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView(new SliderQCViewModel().ListSlider());
        }

        public ActionResult NavBar()
        {
             var hang = (from cd in data.Hangs select cd).ToList();

            return PartialView(hang);
        }
       
    }
}