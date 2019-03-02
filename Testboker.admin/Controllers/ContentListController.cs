using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using Testboker.admin.Models;
using Testboker.admin.Helper;

namespace Testboker.admin.Controllers
{
    public class ContentListController : Controller
    {
        // GET: ContentList
        public ContentListIBLL contentListBLL { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            string ContentListShow = string.IsNullOrEmpty(CookieHelper.GetCookie("ContentListShow"))?"0": CookieHelper.GetCookie("ContentListShow");
            homeViewModel.ContentList = contentListBLL.GetEntities(c=> ContentListShow=="0" ? true : c.IsShow=true);
            return View(homeViewModel);
        }
    }
}