using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using TestBoker.Models;
using Testboker.Model;
using System.Web.Script.Serialization;

namespace TestBoker.Controllers
{
    public class ExhibitionController : Controller
    {
        // GET: Exhibition
        public ExhibitionIBLL exhibitionBLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public string ExhibitionList()
        {
            IEnumerable<Exhibition> contentList = null;
            contentList = exhibitionBLL.GetEntitiesByPpage(10, Convert.ToInt32(Request.Form["pageIndex"]), true, c => c.IsShow == true, c => c.Time);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(contentList);
        }
    }
}