using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopQuanAoLite.Controllers
{
    public class NguoiDungController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile(KhachHang khachhang)
        {
            return View(khachhang);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ViewModels.RegisterViewModel();
                if (dao.CheckUsername(model.TenDangNhap))
                {
                    ViewBag.ThongBao = "Tên đăng nhập đã tồn tại";
                }
                if (dao.CheckUsername(model.TenDangNhap) == false)
                {
                    var customer = new KhachHang();
                    customer.HoTen = model.HoTen;
                    customer.TenDangNhap = model.TenDangNhap;
                    customer.MatKhau = model.MatKhau;
                    customer.DiaChi = model.DiaChi;
                    customer.SoDienThoai = model.SoDienThoai;
                    customer.Email = model.Email;
                    data.KhachHangs.InsertOnSubmit(customer);
                    data.SubmitChanges();
                    ViewBag.ThongBao = "Đăng ký thành công";
                    return View();
                }
            }
            return View(model);
        }

        /*  [HttpPost]
        public ActionResult Dangky(FormCollection collection)
        {
            var tendangnhap = collection["TenDangnhap"];
            var matkhau = collection["MatKhau"];
            var nhaplaimatkhau = collection["NhapLaiMatkhau"];
            var hoten = collection["HoTen"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var sodienthoai = collection["SoDienthoai"];
            if (ModelState.IsValid)
            {
                var dao = new ViewModels.RegisterViewModel();
                if (dao.CheckUsername(tendangnhap))
                {
                    ViewBag.ThongBao="Tên đăng nhập đã tồn tại";
                }
                if (dao.CheckUsername(tendangnhap) == false)
                {
                    var customer = new KhachHang();
                    customer.HoTen = hoten;
                    customer.TenDangNhap = tendangnhap;
                    customer.MatKhau = matkhau;
                    customer.DiaChi = diachi;
                    customer.SoDienThoai = sodienthoai;
                    customer.Email = email;
                    data.KhachHangs.InsertOnSubmit(customer);
                    data.SubmitChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(collection);
        }
         */
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewBag.Thongbao = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewBag.Thongbao = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)
                KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.TenDangNhap == tendangnhap && n.MatKhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                return RedirectToAction("DangKy", "NguoiDung");
            }
            return View();
        }
    }

}