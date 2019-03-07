using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testboker.Model;

namespace Testboker.admin.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<ContentList> ContentList { get; set; }
        public int PageCount = 1;
        public int TableCount = 1;
        public int PageSize = 20;
    }
}