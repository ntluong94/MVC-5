using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;

namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class ProfileAdminController : Controller
    {
        // GET: Admin/Profile
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditPassword(Models.ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var session = (Models.AdminViewModel)Session["Taikhoanadmin"];
                if (session != null)
                {
                    if (session.MatKhau.Equals(model.ExPassword))
                    {
                        var _admin = new QuanTriVien();
                        _admin.MaAdmin = session.MaAdmin;
                        _admin.MatKhau = model.Password.ToString();
                        new Models.ChangePasswordViewModel().EditPassword(_admin);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nhập sai mật khẩu");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản này");
                }
            }
            return View(model);
        }
    }
}