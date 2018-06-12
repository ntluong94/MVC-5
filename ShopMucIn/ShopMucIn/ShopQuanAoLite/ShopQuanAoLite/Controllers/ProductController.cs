using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;
using ShopQuanAoLite.ViewModels;
using PagedList;
using System.Diagnostics;

namespace ShopQuanAoLite.Controllers
{
    public class ProductController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public List<SanPham> SanPham()
        {

            return data.SanPhams.ToList();
        }
     public ActionResult ListProduct(int? Page)
        {
            int pageSize = 12;
            //Tao bien so trang
            int pageNum = (Page ?? 1);
            //Lấy top 5 Album bán chạy nhất
            var layhet = SanPham();
            return PartialView(layhet.ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult Details(int id)
        {
            var sanpham = (from s in data.SanPhams
                           where s.MaSP == id
                           select s).FirstOrDefault();

            var sanPhamCungHang = data.SanPhams
                .Where(sp => sp.Hang == sanpham.Hang)
                .Take(3);
            var binhluan = data.BinhLuans
                .Where(bl => bl.MaSP == id).OrderByDescending(x => x.NgayBL).Take(8);
            var hinhanh = data.HinhAnhs
                .Where(ha => ha.MaSP == id);
            /* var size = from sz in data.Sizes select sz;*/
            // Debugging
            binhluan.ToList().ForEach(bl => Debug.WriteLine(bl.NoiDung));

            var detailView = new DetailedViewModel
            {
                SanPham = sanpham,
                SanPhamCungHang = sanPhamCungHang,
                BinhLuan = binhluan,
                HinhAnh = hinhanh,
            };
            return PartialView(detailView);
        }
        public PartialViewResult DanhMuc(int id)
        {
            var danhmuc = from cd in data.SanPhams
                          where cd.MaH == id
                          select cd;

            return PartialView(danhmuc);
        }
        public PartialViewResult Same_Product(int id)
        {
            var sanpham = new SanPhamViewModel().ListProductByCategory(id);
            return PartialView(sanpham);
        }
        public PartialViewResult ListProductByCategory(int id, int? Page)
        {
            var sanpham = new SanPhamViewModel().ListProductByCategory(id);
            int pageSize = 12;
            //Tao bien so trang
            int pageNum = (Page ?? 1);
            if (sanpham == null)
            {
                ViewBag.sanpham = "Không có sản phẩm nào";
            }
            //Lấy top 5 Album bán chạy nhất
            return PartialView(sanpham.ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult Menu_Category()
        {
            var hangss = (from cd in data.Hangs select cd).ToList();
            return PartialView(hangss);
        }
        public ActionResult SearchResult(string keyword)
        {
            ViewBag.Key = keyword;
            var model = new SanPhamViewModel().Search(keyword);

            ViewBag.KeyWord = keyword;
            return View(model);
        }
        public JsonResult ListName(string keyword)
        {
            var data = new SanPhamViewModel().ListNameProduct(keyword);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}