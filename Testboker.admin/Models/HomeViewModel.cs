using System;
using System.Collections;
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
        public IEnumerable<Exhibition> exhibitionList { get; set; }

        public string WeekDays { get; set; }
        public string YearDays { get; set; }
        public string UserCount { get; set; }
        public string UserName { get; set; }
        public List<string> UserName1 { get; set; }
    }
}