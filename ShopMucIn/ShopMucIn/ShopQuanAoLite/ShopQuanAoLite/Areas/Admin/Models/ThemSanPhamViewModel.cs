using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopQuanAoLite.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopQuanAoLite.Areas.Admin.Models
{
    public class ThemSanPhamViewModel
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int? GiaKhuyenMai { get; set; }
        public int GiaBan { get; set; }
        public int? MaH { get; set; }
        public int? SoLuong { get; set; }
        public string ThongTin { get; set; }
        public DateTime? ngayNhapHang { get; set; }
        public string AnhBia { get; set; }
        public HinhAnh HinhAnhs { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
        public bool EditProduct(SanPham sanpham)
        {
            try
            {
                var viewModel = new ThemSanPhamViewModel
                {
                    MaSP = sanpham.MaSP,
                    TenSP = sanpham.TenSP,
                    GiaKhuyenMai = (int?)sanpham.GiaKhuyenMai,
                    GiaBan = (int)sanpham.GiaBan,
                    MaH = sanpham.MaH,
                    SoLuong = sanpham.SoLuong,
                    ThongTin = sanpham.ThongTin,
                    ngayNhapHang = sanpham.ngayNhapHang,

                };
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}