using ShopQuanAoLite.Areas.Admin.Models;
using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class HangController : Controller
    {
        // GET: Admin/Hang
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: BoSuuTap
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            var hangs = data.Hangs.OrderBy(n => n.MaH);
            return View(hangs);
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
        [ValidateInput(false)]
        public ActionResult Create(Hang hangs, HttpPostedFileBase fileUpload)
        {
            if (String.IsNullOrEmpty(hangs.TenH))
            {
                ViewBag.ThongBao = "Chưa nhập";
            }
            else
            {
                try
                {
                    if (fileUpload == null)
                    {
                        ViewBag.Thongbao = "Chọn ảnh";
                    }
                    //Them vao CSDL
                    else
                    {
                        //if (ModelState.IsValid)
                        {
                            //Luu ten fie, luu y bo sung thu vien using System.IO;
                            var fileName = Path.GetFileName(fileUpload.FileName);
                            //Luu duong dan cua file
                            var path = Path.Combine(Server.MapPath("~/images/hang/anhbia"), fileName);
                            //Kiem tra hình anh ton tai chua?
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.Thongbao = "Thông tin có vấn đề";
                            }
                            else
                            {
                                //Luu hinh anh vao duong dan
                                fileUpload.SaveAs(path);
                            }
                            //Luu vao CSDL  
                            hangs.AnhBia = "images/hang/anhbia/" + fileName;
                            data.Hangs.InsertOnSubmit(hangs);
                            data.SubmitChanges();
                            ViewBag.Thongbao = "SUCCESS";
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ViewBag.ThongBao = "Lỗi nhập Hãng(vd: SamSung,HP... không lớn hơn 50 ký tự)";
                }
            }
            return this.Create();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            Hang hangs = (from s in data.Hangs
                         where s.MaH == id
                         select s).FirstOrDefault();
            if (hangs == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var viewModel = new HangViewModel
            {
                MaH = hangs.MaH,
                TenH = hangs.TenH,
                AnhBia = hangs.AnhBia
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id,HangViewModel viewModel, HttpPostedFileBase files)
        {
          Hang hangs = (from s in data.Hangs
                     where s.MaH == id
                     select s).FirstOrDefault();
             viewModel = new HangViewModel
            {
                MaH = hangs.MaH,
                TenH = hangs.TenH,
                AnhBia = hangs.AnhBia               
            };               
            if (String.IsNullOrEmpty(hangs.TenH))
            {
                ViewBag.ThongBao = "Chưa nhập";
            }
            else
            {
                try
                {
                    if (files != null)
                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/images/hang/anhbia"), fileName);
                        files.SaveAs(path);
                        hangs.AnhBia = "images/hang/anhbia/" + fileName;
                        TryUpdateModel(hangs);
                        data.SubmitChanges();
                        ViewBag.ThongBao = "SUCCESS";
                    }
                    else if (files == null)
                    {
                        ViewData["hinhanh"] = "Phải chọn hình ảnh";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ViewBag.ThongBao = "Lỗi nhập Hãng(vd: SamSung,HP... không lớn hơn 50 ký tự)";
                }
            }
            return this.Create();
        }
        [HttpDelete]
        public ActionResult Delete(int id, Hang hangs)
        {
            hangs = (from s in data.Hangs
                     where s.MaH == id
                     select s).FirstOrDefault();
            SanPham sanpham = (from s in data.SanPhams where s.MaH == id select s).FirstOrDefault();
            
            if (sanpham != null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    data.Hangs.DeleteOnSubmit(hangs);
                    data.SubmitChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View();
                }
            }
        }
    }
}