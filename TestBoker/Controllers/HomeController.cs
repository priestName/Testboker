using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using TestBoker.Models;

namespace TestBoker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public LoginLogIBLL loginLogBLL { get; set; }
        public ContentListIBLL contentListBLL { get; set; }
        public BannerIBLL bannerBLL { get; set; }
        public ActionResult Index()
        {
            string Chrome = Request.ServerVariables["HTTP_USER_AGENT"].ToString();
            string ip = Request.ServerVariables.Get("Remote_Addr").ToString();
            string thisname = System.Net.Dns.GetHostName();
            loginLogBLL.Add(new LoginLog { IP = ip, Name = thisname, Time = DateTime.Now, Chrome = Chrome });

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.contentList = contentListBLL.GetEntities(c => c.IsShow==true);
            return View(homeViewModel);
        }
        public ActionResult Banner()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Banners = bannerBLL.GetEntities(b => b.IsShow == true);
            return PartialView(homeViewModel);
        }

        public void WriteJson(string Text, string TextName)
        {
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(Text + "\r\n");
            using (FileStream fsWrite = new FileStream(@"C:\Users\admin\Desktop\" + TextName, FileMode.Append))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
        }
    }
}