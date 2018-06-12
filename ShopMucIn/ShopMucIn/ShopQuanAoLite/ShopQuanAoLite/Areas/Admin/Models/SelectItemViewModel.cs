using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Areas.Admin.Models
{
    public class SelectItemViewModel
    {
            [Display(Name = "TrangThai List")]
            public SelectList TrangThai { get; set; }
    }
}