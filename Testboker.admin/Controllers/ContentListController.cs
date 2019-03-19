using System;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.admin.Models;
using Testboker.admin.Helper;
using Webdiyer.WebControls.Mvc;
using Testboker.Model;
using System.Linq;

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
            homeViewModel.ContentList = contentListBLL.GetEntitiesByPpage(pageItems, pageIndex, true,c => ContentListShow == "0" ? c.IsShow == true : true,c=>c.Id);
            listViewModel.PageItems = pageItems== listViewModel.PageItems ? listViewModel.PageItems : pageItems;
            listViewModel.ContentList = homeViewModel.ContentList.ToPagedList(pageIndex, listViewModel.PageItems);
            listViewModel.ContentList.PageSize = listViewModel.PageItems;
            listViewModel.ContentList.TotalItemCount = contentListBLL.GetCount(c => ContentListShow == "0" ? c.IsShow == true : true);
            listViewModel.ContentList.CurrentPageIndex = pageIndex;
            return View(listViewModel);
        }
        public ActionResult ContentItem(int id = 0)
        {
            var ContentList = contentListBLL.GetEntities(c => c.Id == id);
            if (id == 0)
            {
                ContentList = new ContentList[] { new Model.ContentList { Id = 0, Title = "", Author = "", Img = "", Label = "", Content = "", IsShow = true } };
            }
            return View(ContentList);
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
            bool IsShowEdit = false;
            Model.ContentList ContentList = new Model.ContentList();
            if (Convert.ToInt32(Request["id"]) != 0)
            {
                ContentList = contentListBLL.GetEntity(c => c.Id == Convert.ToInt32(Request["id"]));
                ContentList.Img = string.IsNullOrEmpty(Request["Img"]) ? ContentList.Img : Request["Img"].ToString();
                ContentList.Label = string.IsNullOrEmpty(Request["Label"]) ? ContentList.Label : Request["Label"].ToString();
                ContentList.Title = string.IsNullOrEmpty(Request["Title"]) ? ContentList.Title : Request["Title"].ToString();
                ContentList.Content = string.IsNullOrEmpty(Request["Content"]) ? ContentList.Content : Request["Content"].ToString();
                ContentList.IsShow = string.IsNullOrEmpty(Request["isShow"]) ? ContentList.IsShow : Request["isShow"].ToString() == "True";
                ContentList.Author = string.IsNullOrEmpty(Request["Author"]) ? ContentList.Content : Request["Author"].ToString();
                ContentList.LastTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                IsShowEdit = contentListBLL.Modify(ContentList);
            }
            else {
                ContentList = new Model.ContentList {
                    Label = string.IsNullOrEmpty(Request["Label"]) ? ContentList.Label : Request["Label"].ToString(),
                    Title = string.IsNullOrEmpty(Request["Title"]) ? ContentList.Title : Request["Title"].ToString(),
                    Content = string.IsNullOrEmpty(Request["Content"]) ? ContentList.Content : Request["Content"].ToString(),
                    IsShow = string.IsNullOrEmpty(Request["isShow"]) ? ContentList.IsShow : Request["isShow"].ToString() == "True",
                    Author = string.IsNullOrEmpty(Request["Author"]) ? ContentList.Content : Request["Author"].ToString(),
                    Img = "aaa.jpg",
                    Time = DateTime.Now
            };
                IsShowEdit = contentListBLL.Add(ContentList);
            }
            Response.Write(IsShowEdit.ToString());
        }

    }
}