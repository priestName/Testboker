using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.admin.Models;
using Testboker.admin.Helper;
using Webdiyer.WebControls.Mvc;

namespace Testboker.admin.Controllers
{
    public class ContentListController : Controller
    {
        // GET: ContentList
        public ContentListIBLL contentListBLL { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        ListViewModel listViewModel = new ListViewModel();
        public ActionResult Index(int pageIndex = 1,int pageItems = 25)
        {
            string ContentListShow = string.IsNullOrEmpty(CookieHelper.GetCookie("ContentListShow"))?"0": CookieHelper.GetCookie("ContentListShow");
            homeViewModel.ContentList = contentListBLL.GetEntities(c => true);
            listViewModel.PageItems = pageItems== listViewModel.PageItems ? listViewModel.PageItems : pageItems;
            listViewModel.ContentList = homeViewModel.ContentList.ToPagedList(pageIndex, listViewModel.PageItems);
            listViewModel.ContentList.PageSize = listViewModel.PageItems;
            listViewModel.ContentList.TotalItemCount = contentListBLL.GetCount(c => true); ;
            listViewModel.ContentList.CurrentPageIndex = pageIndex;
            return View(listViewModel);
        }
    }
}