using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.admin.Models;
using Testboker.IBLL;
using Testboker.Model;
using Webdiyer.WebControls.Mvc;

namespace Testboker.admin.Controllers
{
    public class VisitMainListController : Controller
    {
        public LoginLogIBLL loginlog { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        ListViewModel listViewModel = new ListViewModel();
        // GET: VisitMainList
        public ActionResult VisitOpinions()
        {
            return View();
        }
        public ActionResult VisitArticle()
        {
            return View();
        }
        public ActionResult VisitList(int pageIndex = 1, int pageItems = 25)
        {
            homeViewModel.LoginLog = loginlog.GetEntitiesByPpage(pageItems, pageIndex, true, c => true, c => c.Id);
            listViewModel.PageItems = pageItems == listViewModel.PageItems ? listViewModel.PageItems : pageItems;
            listViewModel.LoginLog = homeViewModel.LoginLog.ToPagedList(pageIndex, listViewModel.PageItems);
            listViewModel.LoginLog.PageSize = listViewModel.PageItems;
            listViewModel.LoginLog.TotalItemCount = loginlog.GetCount(c => true);
            listViewModel.LoginLog.CurrentPageIndex = pageIndex;
            return View(listViewModel);
        }
    }
}