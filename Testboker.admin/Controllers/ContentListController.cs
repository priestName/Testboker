using System;
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
            var a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ContentListShow = string.IsNullOrEmpty(CookieHelper.GetCookie("ContentListShow"))?"0": CookieHelper.GetCookie("ContentListShow");
            //homeViewModel.ContentList = contentListBLL.GetEntities(c => ContentListShow=="0"? c.IsShow == true : true);
            homeViewModel.ContentList = contentListBLL.GetEntitiesByPpage(pageItems, pageIndex, true,c => ContentListShow == "0" ? c.IsShow == true : true,c=>c.Id);
            listViewModel.PageItems = pageItems== listViewModel.PageItems ? listViewModel.PageItems : pageItems;
            listViewModel.ContentList = homeViewModel.ContentList.ToPagedList(pageIndex, listViewModel.PageItems);
            listViewModel.ContentList.PageSize = listViewModel.PageItems;
            listViewModel.ContentList.TotalItemCount = contentListBLL.GetCount(c => ContentListShow == "0" ? c.IsShow == true : true);
            listViewModel.ContentList.CurrentPageIndex = pageIndex;
            return View(listViewModel);
        }
        public void ListShow()
        {
            Model.ContentList ContentList =contentListBLL.GetEntity(c => c.Id == Convert.ToInt32(Request["id"]));
            ContentList.IsShow = Request["isShow"].ToString() == "True";
            bool IsShowEdit = contentListBLL.Modify(ContentList);
            Response.Write(IsShowEdit.ToString());
        }
        public void EditContent()
        {
            Model.ContentList ContentList = contentListBLL.GetEntity(c => c.Id == Convert.ToInt32(Request["id"]));
            ContentList.Img = Request["Img"].ToString();
            ContentList.Label= Request["Label"].ToString();
            ContentList.Title = Request["Title"].ToString();
            ContentList.LastTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ContentList.Content= string.IsNullOrEmpty(Request["Content"].ToString())? ContentList.Content : Request["Content"].ToString();
            ContentList.IsShow =string.IsNullOrEmpty(Request["isShow"].ToString())? ContentList.IsShow:Request["isShow"].ToString() == "True";
            bool IsShowEdit = contentListBLL.Modify(ContentList);
            Response.Write(IsShowEdit.ToString());
        }

    }
}