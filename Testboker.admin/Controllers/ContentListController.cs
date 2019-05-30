using System;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.admin.Models;
using Testboker.admin.Helper;
using Webdiyer.WebControls.Mvc;
using Testboker.Model;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq.Expressions;
using System.Linq;

namespace Testboker.admin.Controllers
{
    public class ContentListController : Controller
    {
        // GET: ContentList
        public ContentListIBLL contentListBLL { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        ListViewModel listViewModel = new ListViewModel();
        public ActionResult Index(int pageIndex = 1, int pageItems = 25,string where= "")
        {
            ContentListWhere ModelWhere= new JavaScriptSerializer().Deserialize<ContentListWhere>(where);
            homeViewModel.ContentList = contentListBLL.GetEntitiesByPpage(pageItems, pageIndex, true, Lambdas(ModelWhere), c => c.Id);

            listViewModel.PageItems = pageItems == listViewModel.PageItems ? listViewModel.PageItems : pageItems;
            listViewModel.ContentList = homeViewModel.ContentList==null?null:homeViewModel.ContentList.ToPagedList(pageIndex, listViewModel.PageItems);
            listViewModel.ContentList.PageSize = listViewModel.PageItems;
            listViewModel.ContentList.TotalItemCount = contentListBLL.GetCount(Lambdas(ModelWhere));
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
            int id = Convert.ToInt32(Request["id"]);
            Model.ContentList ContentList = contentListBLL.GetEntity(c => c.Id == id);
            ContentList.IsShow = Request["isShow"].ToString() == "True";
            bool IsShowEdit = contentListBLL.Modify(ContentList);
            Response.Write(IsShowEdit.ToString());
        }
        public void EditContent()
        {
            bool IsShowEdit = false;
            int id = Convert.ToInt32(Request["id"]);
            Model.ContentList ContentList = new Model.ContentList();
            ContentList = contentListBLL.GetEntity(c => c.Id == id);
            if (!string.IsNullOrEmpty(Request["ImgBase"]))
            {
                string ImgBase = Request["ImgBase"].ToString();
                ImgBase = ImgBase.Substring(ImgBase.IndexOf("base64,")+7);
                if (ContentList == null)
                    BaseInImg(ImgBase, Request["ImgName"].ToString());
                else if (Request["ImgName"].ToString() != ContentList.Img)
                    BaseInImg(ImgBase, Request["ImgName"].ToString());
            }

            if (ContentList !=null)
            {
                ContentList.Img = string.IsNullOrEmpty(Request.Form["ImgName"]) ? ContentList.Img : Request["ImgName"].ToString();
                ContentList.Label = string.IsNullOrEmpty(Request.Form["Label"]) ? ContentList.Label : Request["Label"].ToString();
                ContentList.Title = string.IsNullOrEmpty(Request.Form["Title"]) ? ContentList.Title : Request["Title"].ToString();
                ContentList.Content = string.IsNullOrEmpty(Request.Form["Content"]) ? ContentList.Content : Request["Content"].ToString();
                ContentList.IsShow = string.IsNullOrEmpty(Request.Form["isShow"]) ? ContentList.IsShow : Request["isShow"].ToString() == "True";
                ContentList.Author = string.IsNullOrEmpty(Request.Form["Author"]) ? ContentList.Author : Request["Author"].ToString();
                ContentList.LastTime = DateTime.Now;
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
            string dbstring = Directory.GetParent(Server.MapPath("~/")).Parent.FullName + @"\TestBoker\Content\ContentImg\";
            bmp.Save(dbstring + ImgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Save(Server.MapPath("~/Content/ContentImg/") + ImgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();

        }
        public Expression<Func<ContentList, bool>> Lambdas(ContentListWhere Where)
        {
            Expression<Func<ContentList, bool>> exp = LambdasHelper.True<ContentList>() ;
            if (CookieHelper.GetCookie("ContentListShow") == "1")
                exp = exp.And(c => c.IsShow == true);
            if (Where == null) return exp;
            if (!string.IsNullOrEmpty(Where.Author))
                exp = exp.And(c => c.Author.Contains(Where.Author));
            if (!string.IsNullOrEmpty(Where.Content))
                exp = exp.And(c => c.Content.Contains(Where.Content));
            if (!string.IsNullOrEmpty(Where.Title))
                exp = exp.And(c => c.Title.Contains(Where.Title));
            if (!string.IsNullOrEmpty(Where.Label))
                exp = exp.And(c => c.Label.Contains(Where.Label));
            if (!string.IsNullOrEmpty(Where.LastTime1))
                exp = exp.And(c => c.LastTime >= DateTime.Parse(Where.LastTime1));
            if (!string.IsNullOrEmpty(Where.LastTime2))
                exp = exp.And(c => c.LastTime <= DateTime.Parse(Where.LastTime2));
            if (!string.IsNullOrEmpty(Where.Time1))
                exp = exp.And(c => c.Time >= DateTime.Parse(Where.Time1));
            if (!string.IsNullOrEmpty(Where.Time2))
                exp = exp.And(c => c.Time <= DateTime.Parse(Where.Time2));
            return exp;
        }
    }
}