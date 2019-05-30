using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.admin.Models;
using Testboker.IBLL;

namespace Testboker.admin.Controllers
{
    public class BannerController : Controller
    {
        public BannerIBLL bannerBLL { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        ListViewModel listViewModel = new ListViewModel();
        public ActionResult Index(int pageIndex = 1, int pageItems = 25, string where = "")
        {
            homeViewModel.Banners = bannerBLL.GetEntitiesByPpage(pageItems, pageIndex, true, b => true, b => b.Id);
            return View();
        }
    }
}