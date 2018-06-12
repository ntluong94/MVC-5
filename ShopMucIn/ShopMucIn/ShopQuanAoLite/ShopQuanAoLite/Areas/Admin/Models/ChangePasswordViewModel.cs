using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShopQuanAoLite.Models;

namespace ShopQuanAoLite.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
         dbShopQuanAoDataContext admin;
        public ChangePasswordViewModel()
        {
            admin = new dbShopQuanAoDataContext();
        }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu cũ")]
        public string ExPassword { set; get; }

        [Display(Name = "New-Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu tối thiểu 6 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu mới")]
        public string Password { set; get; }

        [Display(Name = "Retype-Password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [Required(ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { set; get; }
        public List<QuanTriVien> ListAdmin()
        {
            return admin.QuanTriViens.ToList();
        }

        public QuanTriVien GetByID(int id)
        {
            return admin.QuanTriViens.Where(ad => ad.MaAdmin == id).FirstOrDefault();
        }
        public bool CreateAdmin(QuanTriVien _admin)
        {
            try
            {
                admin.QuanTriViens.InsertOnSubmit(_admin);
                admin.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                var entity = admin.QuanTriViens.Where(ad => ad.MaAdmin == id).FirstOrDefault();
                admin.QuanTriViens.DeleteOnSubmit(entity);
                admin.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditPassword(QuanTriVien _admin)
        {
            try
            {
                var entity = admin.QuanTriViens.Where(ad => ad.MaAdmin == _admin.MaAdmin).FirstOrDefault();
                entity.MatKhau = _admin.MatKhau;
                admin.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}