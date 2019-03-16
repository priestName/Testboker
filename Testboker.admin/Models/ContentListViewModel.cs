using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testboker.Model;

namespace Testboker.admin.Models
{
    public class ContentListViewModel
    {
        public IEnumerable<ContentList> ContentList { get; set; }
        public ContentList ContentItem { get; set; }
    }
}