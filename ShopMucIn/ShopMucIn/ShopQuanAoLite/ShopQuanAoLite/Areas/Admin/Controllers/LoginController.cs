using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;
using ShopQuanAoLite.Areas.Admin.Models;
namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            //Gán giá trị cho đối tượng được tạo mới (ad)                      
            ShopQuanAoLite.Models.QuanTriVien admin = data.QuanTriViens.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
            if (admin != null)
            {
                // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                Session["Taikhoanadmin"] = admin;
                var adminSession = new AdminViewModel();

                adminSession.MaAdmin = admin.MaAdmin;
                adminSession.TaiKhoan = admin.TaiKhoan;
                adminSession.Email = admin.Email;
                adminSession.MatKhau = admin.MatKhau;
                adminSession.Phanloai = (bool)admin.PhanLoai;
                adminSession.TenAdmin = admin.TenAdmin;
                Session.Add("Taikhoanadmin", adminSession);
                return RedirectToAction("Index", "AdminHome");
            }
            else
                ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";

            return View();
        }
        public ActionResult Logout()
        {
            Session["Taikhoanadmin"] = null;
            return RedirectToAction("Index","AdminHome");
        }
    }
}