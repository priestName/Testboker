using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using TestBoker.Models;

namespace TestDoker.Controllers
{
    public class ContentListController : Controller
    {
        // GET: ContentList
        public ContentListIBLL contentListBLL { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.contentList = contentListBLL.GetEntities(c => c.IsShow == true);
            return View(homeViewModel);
        }
    }
}