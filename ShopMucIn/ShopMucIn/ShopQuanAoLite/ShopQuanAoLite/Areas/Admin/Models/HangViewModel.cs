using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAoLite.Areas.Admin.Models
{
    public class HangViewModel
    {
        public int MaH { get; set; }
        public string TenH { get; set; }
        public string AnhBia { get; set; }
        public HttpPostedFileBase files { get; set; }
    }
}