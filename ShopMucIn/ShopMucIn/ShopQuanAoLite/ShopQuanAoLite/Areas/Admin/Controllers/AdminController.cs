using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAoLite.Models;
using ShopQuanAoLite.Areas.Admin.Models;


namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            return View(new Models.ChangePasswordViewModel().ListAdmin());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuanTriVien _admin)
        {
            _admin.MatKhau = _admin.MatKhau.ToString();
            new Models.ChangePasswordViewModel().CreateAdmin(_admin);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new Models.ChangePasswordViewModel().DeleteAdmin(id);
            return RedirectToAction("Index");
        }
    }
}