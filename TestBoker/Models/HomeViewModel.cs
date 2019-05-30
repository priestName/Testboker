using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testboker.Model;

namespace TestBoker.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<ContentList> contentList { get; set; }
        public IEnumerable<ContentList> exhibitionList { get; set; }
    }
}