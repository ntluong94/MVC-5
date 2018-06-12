using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShopQuanAoLite.Models;

namespace ShopQuanAoLite.ViewModels
{  
    public class ChangeProfileViewModel
    {
        dbShopQuanAoDataContext customer;
        public ChangeProfileViewModel()
        {
            customer = new dbShopQuanAoDataContext();
        }

        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Username")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage = "Yêu cầu nhập đúng số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ hòm thư điện tử")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string ExPassword { set; get; }

        [Display(Name = "New-Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu tối thiểu 6 ký tự")]
        public string Password { set; get; }

        [Display(Name = "Retype-Password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { set; get; }
        public bool EditCustomer(KhachHang _customer)
        {
            try
            {
                var entity = customer.KhachHangs.Where(kh =>kh.MaKH==_customer.MaKH).FirstOrDefault();
                entity.HoTen = _customer.HoTen;
                entity.TenDangNhap = _customer.TenDangNhap;
                entity.MatKhau = _customer.MatKhau;
                entity.DiaChi = _customer.DiaChi;
                entity.SoDienThoai = _customer.SoDienThoai;
                entity.Email = _customer.Email;
                customer.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public List<HoaDon> ListByCustomerID(int id)
        {
            return customer.HoaDons.Where(x => x.MaKH == id).ToList();
        }

        public List<ChiTietHoaDon> ListOrderFormDetail(int id)
        {
            return customer.ChiTietHoaDons.Where(x => x.MaHD == id).ToList();
        }
    }
}