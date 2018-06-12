using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopQuanAoLite.Models;
namespace ShopQuanAoLite.ViewModels
{
    public class SliderQCViewModel
    {
        dbShopQuanAoDataContext data;
        public SliderQCViewModel()
        {
            data = new dbShopQuanAoDataContext();
        }
        public List<QuangCao> ListAdvertisement()
        {
            return data.QuangCaos.ToList();
        }

        public List<QuangCao> ListSlider()
        {
            return data.QuangCaos.ToList().Where(x => x.HinhAnhQC.StartsWith("/images/quangcao/")).ToList();
        }

    }
}