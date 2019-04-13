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
        public IEnumerable<LoginLog> LoginLog { get; set; }
    }
}