using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAoLite
{
    public class DetailedViewModel
    {
        public SanPham SanPham { get; set; }
        public IEnumerable<SanPham> SanPhamCungHang { get; set; }
        public IEnumerable<BinhLuan> BinhLuan { get; set; }
        public IEnumerable<HinhAnh> HinhAnh { get; set; }
        public BinhLuan BinhLuans { get; set; }

    }
}