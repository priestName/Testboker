using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using Testboker.admin.Models;
using System.Web.Script.Serialization;

namespace Testboker.admin.Controllers
{
    public class HomeController : Controller
    {
        public LoginLogIBLL loginlog { get; set; }
        public HomeViewModel homeViewModel = new HomeViewModel();
        // GET: Home
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult Index()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<int> WeekDays = new List<int> {0,0,0,0,0,0,0};
            List<int> YearDays = new List<int> {0,0,0,0,0,0,0,0,0,0,0,0 };
            var time = DateTime.Now.AddDays(-6).Date;
            var WeekList = loginlog.GetEntities(c => c.Time >= time).GroupBy(c=>c.Time.Date).Select(c=>new {key=c.Key,value=c.Count() }).ToList();
            foreach (var item in WeekList)
            {
                WeekDays[6-(DateTime.Now.Date- item.key.Date).Days] = item.value;
            }
            var YearList = loginlog.GetEntities(c => c.Time.Year == time.Year).GroupBy(c => c.Time.Month).Select(c => new { key = c.Key, value = c.Count() }).ToList();
            foreach (var item in YearList)
            {
                YearDays[item.key-1] = item.value;
            }
            homeViewModel.WeekDays = jss.Serialize(WeekDays);
            homeViewModel.YearDays = jss.Serialize(YearDays);
            var UserList = loginlog.GetEntities(c => c.Time.Year == time.Year).GroupBy(l => l.IP).Select(c => new { key = c.Key, value = c.Count() }).OrderByDescending(l => l.value).Take(10).ToList();

            //var UserList1 = loginlog.GetEntities(c => c.Time.Year == time.Year).ToList();
            //var UserList2 = (from a in UserList1 group a by a.IP into g select new { Key=g.Key, Value = g.Count(), Date = g.Max(x => x.Time)}).ToList();

            homeViewModel.UserCount = jss.Serialize(UserList.Select(c => c.value));
            homeViewModel.UserName = jss.Serialize(UserList.Select(c => c.key));
            return View(homeViewModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Nav()
        {
            return View();
        }
        public ActionResult Banner()
        {
            return View();
        }

        public ActionResult GetLargeJsonResult(List<string> listResult)
        {
            return new ContentResult
            {
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(listResult),
                ContentType = "application/json"
            };
        }
    }
}