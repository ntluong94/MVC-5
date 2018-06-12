using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAoLite.Areas.Admin.Models
{
    [Serializable]
    public class AdminViewModel
    {
        public int MaAdmin { set; get; }
        public String TaiKhoan { set; get; }
        public String TenAdmin { set; get; }
        public String Email { set; get; }
        public String MatKhau { set; get; }
        public bool Phanloai { set; get; }
    }
}