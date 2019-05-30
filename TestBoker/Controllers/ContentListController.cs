using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
            return View();
        }
        public ActionResult ContentItem()
        {
            return View();
        }
        public string contentList()
        {
            IEnumerable<ContentList> contentList = null;
            string searchText = Request.Form["searchText"];
            if (string.IsNullOrEmpty(searchText))
                contentList = contentListBLL.GetEntitiesByPpage(10, Convert.ToInt32(Request.Form["pageIndex"]), true, c => c.IsShow == true, c => c.Time);
            else
                contentList = contentListBLL.GetEntitiesByPpage(10, Convert.ToInt32(Request.Form["pageIndex"]), true, 
                    c => c.IsShow == true && (
                    c.Label.Contains(searchText) || 
                    c.Title.Contains(searchText) || 
                    c.Author.Contains(searchText) || 
                    c.Content.Contains(searchText) ), 
                    c => c.Time);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(contentList);
            return json;
        }
    }
}