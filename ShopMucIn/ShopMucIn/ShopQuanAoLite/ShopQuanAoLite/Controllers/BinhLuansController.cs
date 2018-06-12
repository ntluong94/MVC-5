using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;
using ShopQuanAoLite.ViewModels;

namespace ShopQuanAoLite.Controllers
{
    public class BinhLuansController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: BinhLuans
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            SanPham sanphams = data.SanPhams.SingleOrDefault(n => n.MaSP == id);
            // Giữ lại MaSP cho binhluans => HttpPost
            var binhluans = new BinhLuan();
            binhluans.MaSP = sanphams.MaSP;
            return View(binhluans);
        }
        [HttpPost]
        public ActionResult Create(BinhLuan binhluans)
        {
     
            var product = new dbShopQuanAoDataContext();
            KhachHang kh = (KhachHang)Session["Taikhoan"];
                binhluans.MaKH = kh.MaKH;
                DateTime date = DateTime.Now;
                binhluans.NgayBL = date;
                binhluans.TrangThai = true;
                data.BinhLuans.InsertOnSubmit(binhluans);
                data.SubmitChanges();
            return RedirectToAction("Details", "Product",new {id=binhluans.MaSP});
        }
    }
}