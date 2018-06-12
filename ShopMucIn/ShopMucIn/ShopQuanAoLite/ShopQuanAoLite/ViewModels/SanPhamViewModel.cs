using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAoLite.ViewModels
{
    public class SanPhamViewModel
    {
        dbShopQuanAoDataContext product;
        public SanPhamViewModel()
        {
            product = new dbShopQuanAoDataContext();
        }
        public List<SanPham> ListProduct(ref int totalRecord, int pageIndex = 1, int pageSize = 3)
        {
            totalRecord = (from cd in product.SanPhams select cd.MaSP).Count();
            return product.SanPhams.OrderByDescending(x => x.ngayNhapHang).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<SanPham> ListProductByCategory(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 3)
        {
            totalRecord = product.SanPhams.Where(x => x.Hang.MaH == id).Count();
            return product.SanPhams.Where(x => x.Hang.MaH == id).OrderByDescending(x => x.ngayNhapHang).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<SanPham> ListProductByCategory(int id)
        {
            return product.SanPhams.Where(x => x.Hang.MaH == id).ToList();
        }
        public List<SanPham> Search(string keyword)
        {         
            return product.SanPhams.Where(x => x.TenSP.Contains(keyword)).OrderByDescending(x => x.ngayNhapHang).ToList();
        }
        public List<string> ListNameProduct(string keyword)
        {
            return product.SanPhams.Where(x => x.TenSP.Contains(keyword)).Select(x => x.TenSP).ToList();
        }
    }
}