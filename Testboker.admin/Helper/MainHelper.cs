using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Testboker.admin.Helper
{
    public class MainHelper
    {
        public void BaseInImg(string ImgBase, string ImgName)
        {
            byte[] arr = Convert.FromBase64String(ImgBase);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            string dbstring = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\ContentImg\";
            //string dbstring = Directory.GetParent(Server.MapPath("~/")).Parent.FullName + @"\TestBoker\Content\ContentImg\";
            bmp.Save(dbstring + ImgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            //bmp.Save(Server.MapPath("~/Content/ContentImg/") + ImgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();

        }
    }
}