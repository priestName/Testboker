using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testboker.Model;
using Webdiyer.WebControls.Mvc;

namespace Testboker.admin.Models
{
    public class ListViewModel
    {
        public PagedList<ContentList> ContentList { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }
        public string SortBy { get; set; }
        public int NumericPagerItemCount { get; set; }
        public int PageCount { get; set; }
        public int PageItems = 25;
    }
}