using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class QuangCaoController : Controller
    {
        // GET: Admin/QuangCao
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();

        // GET: QuangCao
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            var quangcaos = data.QuangCaos.OrderBy(n => n.MaQC);
            return View(quangcaos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuangCao quangcaos)
        {
            data.QuangCaos.InsertOnSubmit(quangcaos);
            data.SubmitChanges();
            ViewBag.ThongBao = "SUCCESS";
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id, QuangCao quangcaos)
        {
           quangcaos = (from s in data.QuangCaos
                         where s.MaQC == id
                         select s).FirstOrDefault();
            data.QuangCaos.DeleteOnSubmit(quangcaos);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}