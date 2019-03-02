using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testboker.Model;

namespace TestBoker.Models
{
    public class ExhibitionViewModel
    {
        public IEnumerable<Exhibition> exhibitionList { get; set; }
    }
}