using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using Testboker.admin.Models;

namespace Testboker.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
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
    }
}