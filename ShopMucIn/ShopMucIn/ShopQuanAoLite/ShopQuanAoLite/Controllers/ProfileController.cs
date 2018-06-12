using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.ViewModels;

namespace ShopQuanAoLite.Controllers
{
    public class ProfileController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            var session = (KhachHang)Session["Taikhoan"];
            var profile = new ChangeProfileViewModel();
            if (session != null)
            {
                var entity = data.KhachHangs.Where(kh => kh.MaKH == session.MaKH).FirstOrDefault();
                profile.HoTen = entity.HoTen;
                profile.TenDangNhap = entity.TenDangNhap;
                profile.DiaChi = entity.DiaChi;
                profile.SoDienThoai = entity.SoDienThoai;
                profile.Email = entity.Email;   
                return View(profile);
            }
                return View();
        }
        [HttpPost]
        public ActionResult Index(ChangeProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var session = (KhachHang)Session["Taikhoan"];
                var khachhang = data.KhachHangs.Where(kh => kh.MaKH == session.MaKH).FirstOrDefault();
                try
                {
                    if (session != null)
                    {
                        var entity = new KhachHang();
                        entity.MaKH = session.MaKH;
                        entity.HoTen = model.HoTen;
                        entity.TenDangNhap = model.TenDangNhap;
                        entity.DiaChi = model.DiaChi;
                        entity.SoDienThoai = model.SoDienThoai;
                        entity.Email = model.Email;
                        if (model.ExPassword != null)
                        {
                            if (session.MatKhau.Equals(model.ExPassword))
                            {
                                entity.MatKhau = model.ConfirmPassword.ToString();
                            }
                            else
                            {
                                ModelState.AddModelError("", "Nhập sai mật khẩu");
                            }
                        }
                        new ChangeProfileViewModel().EditCustomer(entity);
                        TryUpdateModel(khachhang);
                        data.SubmitChanges();
                    }
                }
                catch
                {

                }
            }
                    
            return View(model);
        }
        public ActionResult ModifySuccess()
        {
            return View();
        }
        public ActionResult LichSu_MuaHang()
        {
            var session = (KhachHang)Session["Taikhoan"];
            List<HoaDon> list = new List<HoaDon>();
            if (session != null)
            {
                list = new ChangeProfileViewModel().ListByCustomerID(session.MaKH);
            }
            return View(list);
        }

        public ActionResult ChiTiet_LichSu_MuaHang(int id)
        {
            ViewBag.ID = id;
            return View(new ChangeProfileViewModel().ListOrderFormDetail(id));
        }
    }
}