using System;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.admin.Models;
using Testboker.admin.Helper;
using Webdiyer.WebControls.Mvc;
using Testboker.Model;
using System.Linq;
using System.Drawing;
using System.IO;

namespace Testboker.admin.Controllers
{
    public class ContentListController : Controller
    {
        // GET: ContentList
        public ContentListIBLL contentListBLL { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        ListViewModel listViewModel = new ListViewModel();
        public ActionResult Index(int pageIndex = 1, int pageItems = 25)
        {
            var a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ContentListShow = string.IsNullOrEmpty(CookieHelper.GetCookie("ContentListShow")) ? "0" : CookieHelper.GetCookie("ContentListShow");
            homeViewModel.ContentList = contentListBLL.GetEntitiesByPpage(pageItems, pageIndex, true, c => ContentListShow == "0" ? c.IsShow == true : true, c => c.Id);
            listViewModel.PageItems = pageItems == listViewModel.PageItems ? listViewModel.PageItems : pageItems;
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
                ContentList = new ContentList[] { new Model.ContentList { Id = 0, Title = "", Author = "", Img = "AddImg.jpg", Label = "", Content = "", IsShow = true } };
            }
            return View(ContentList);
        }
        public void ListShow()
        {
            Model.ContentList ContentList = contentListBLL.GetEntity(c => c.Id == Convert.ToInt32(Request["id"]));
            ContentList.IsShow = Request["isShow"].ToString() == "True";
            bool IsShowEdit = contentListBLL.Modify(ContentList);
            Response.Write(IsShowEdit.ToString());
        }
        public void EditContent()
        {
            bool IsShowEdit = false;
            Model.ContentList ContentList = new Model.ContentList();
            ContentList = contentListBLL.GetEntity(c => c.Id == Convert.ToInt32(Request["id"]));
            if (!string.IsNullOrEmpty(Request["ImgBase"]))
            {
                string ImgBase = Request["ImgBase"].ToString();
                ImgBase = ImgBase.Substring(ImgBase.IndexOf("base64,")+7);
                if (ContentList == null)
                    BaseInImg(ImgBase, Request["ImgName"].ToString());
                else if (ImgBase != ContentList.Img)
                    BaseInImg(ImgBase, Request["ImgName"].ToString());
            }

            if (Convert.ToInt32(Request["id"]) != 0)
            {
                ContentList.Img = string.IsNullOrEmpty(Request["ImgName"]) ? ContentList.Img : Request["ImgName"].ToString();
                ContentList.Label = string.IsNullOrEmpty(Request["Label"]) ? ContentList.Label : Request["Label"].ToString();
                ContentList.Title = string.IsNullOrEmpty(Request["Title"]) ? ContentList.Title : Request["Title"].ToString();
                ContentList.Content = string.IsNullOrEmpty(Request["Content"]) ? ContentList.Content : Request["Content"].ToString();
                ContentList.IsShow = string.IsNullOrEmpty(Request["isShow"]) ? ContentList.IsShow : Request["isShow"].ToString() == "True";
                ContentList.Author = string.IsNullOrEmpty(Request["Author"]) ? ContentList.Content : Request["Author"].ToString();
                ContentList.LastTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                IsShowEdit = contentListBLL.Modify(ContentList);
            }
            else
            {
                ContentList = new Model.ContentList
                {
                    Label = string.IsNullOrEmpty(Request["Label"]) ? ContentList.Label : Request["Label"].ToString(),
                    Title = string.IsNullOrEmpty(Request["Title"]) ? ContentList.Title : Request["Title"].ToString(),
                    Content = string.IsNullOrEmpty(Request["Content"]) ? ContentList.Content : Request["Content"].ToString(),
                    IsShow = string.IsNullOrEmpty(Request["isShow"]) ? ContentList.IsShow : Request["isShow"].ToString() == "True",
                    Author = string.IsNullOrEmpty(Request["Author"]) ? ContentList.Content : Request["Author"].ToString(),
                    Img = string.IsNullOrEmpty(Request["ImgName"]) ? ContentList.Img : Request["ImgName"].ToString(),
                    Time = DateTime.Now
                };
                IsShowEdit = contentListBLL.Add(ContentList);
            }
            Response.Write(IsShowEdit.ToString());
        }

        public void BaseInImg(string ImgBase, string ImgName)
        {
            byte[] arr = Convert.FromBase64String(ImgBase);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(@"E:/priestName/Testboker/TestBoker/Content/ContentImg/" + ImgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();

        }
    }
}