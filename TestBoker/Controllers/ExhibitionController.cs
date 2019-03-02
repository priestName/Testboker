using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testboker.IBLL;
using Testboker.Model;
using TestBoker.Models;

namespace TestBoker.Controllers
{
    public class ExhibitionController : Controller
    {
        // GET: Exhibition
        public ExhibitionIBLL exhibitionBLL { get; set; }
        public ActionResult Index()
        {
            ExhibitionViewModel exhibitionViewModel = new ExhibitionViewModel();
            exhibitionViewModel.exhibitionList = exhibitionBLL.GetEntities(e => true);
            return View(exhibitionViewModel);
        }
    }
}