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
    public class ExhibitionController : Controller
    {
        // GET: Exhibition
        public ExhibitionIBLL exhibitionBLL { get; set; }
        static HomeViewModel homeViewModel = new HomeViewModel();
        public ActionResult Index(int pageItems=25, int pageIndex=1,string Where="")
        {
            ExhibitionWhere ModelWhere = new JavaScriptSerializer().Deserialize<ExhibitionWhere>(Where);
            HomeViewModel exhibitionViewModel = new HomeViewModel {
                exhibitionList = exhibitionBLL.GetEntitiesByPpage(pageItems, pageIndex, true, Lambdas(ModelWhere), c => c.Id)
            };
            ListViewModel listViewModel = new ListViewModel {
                PageItems = pageItems,
                Exhibition = exhibitionViewModel.exhibitionList.ToPagedList(pageIndex, pageItems)
            };
            
            listViewModel.Exhibition.PageSize = listViewModel.PageItems;
            listViewModel.Exhibition.TotalItemCount = exhibitionBLL.GetCount(c => true);
            listViewModel.Exhibition.CurrentPageIndex = pageIndex;
            return View(listViewModel);
        }
        public ActionResult ExhibitionItem(int id = 0)
        {
            var Exhibition = exhibitionBLL.GetEntities(c => c.Id == id);
            if (id == 0)
            {
                Exhibition = new Exhibition[] { new Model.Exhibition { Id = 0, Title = "", Img = "AddImg.jpg", Synopsis = "", Src = "", IsShow = true } };
            }
            return View(Exhibition);
        }

        public void EditAndUpdate()
        {
            string IsShowEdit = "false";
            int id = Convert.ToInt32(Request["id"] ?? "0");
            try
            {
                Model.Exhibition exhibition = new Model.Exhibition();
                if (id != 0)
                {
                    exhibition = exhibitionBLL.GetEntity(c => c.Id == id);
                }
                if (!string.IsNullOrEmpty(Request["ImgBase"]))
                {
                    string ImgBase = Request["ImgBase"].ToString();
                    ImgBase = ImgBase.Substring(ImgBase.IndexOf("base64,") + 7);
                    if (Request["ImgName"].ToString() != exhibition.Img)
                        BaseInImg(ImgBase, Request["ImgName"].ToString());
                }
                exhibition.Title = Request.Form["Title"];
                exhibition.Src = Request.Form["SrcUrl"];
                exhibition.Img = Request.Form["ImgName"];
                exhibition.IsShow = Request.Form["IsShow"]=="0";
                exhibition.Synopsis = Request.Form["Synopsis"];
                exhibition.Time = DateTime.Now;
                if (id == 0)
                {
                    IsShowEdit = exhibitionBLL.Add(exhibition).ToString();
                }
                else {
                    exhibition.Id = id;
                    IsShowEdit=exhibitionBLL.Modify(exhibition).ToString();
                }
            }
            catch (Exception e)
            {
                IsShowEdit = e.Message;
                throw;
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
        public Expression<Func<Exhibition, bool>> Lambdas(ExhibitionWhere Where)
        {
            Expression<Func<Exhibition, bool>> exp = LambdasHelper.True<Exhibition>();
            if (Where != null)
            {
                if (!string.IsNullOrEmpty(Where.Title))
                    exp = exp.And(c => c.Title.Contains(Where.Title));
                if (!string.IsNullOrEmpty(Where.Synopsis))
                    exp = exp.And(c => c.Title.Contains(Where.Synopsis));
                if (!string.IsNullOrEmpty(Where.Time1))
                    exp = exp.And(c => c.Time >= DateTime.Parse(Where.Time1));
                if (!string.IsNullOrEmpty(Where.Time2))
                    exp = exp.And(c => c.Time <= DateTime.Parse(Where.Time2));
            }
            return exp;
        }
    }
}