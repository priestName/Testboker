namespace Testboker.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exhibition")]
    public partial class Exhibition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Img { get; set; }

        [Required]
        public string Src { get; set; }

        public string Synopsis { get; set; }

        public DateTime Time { get; set; }

        public bool IsShow { get; set; }
    }
    public partial class ExhibitionWhere
    {
        public string Title = string.Empty;
        public string Synopsis = string.Empty;
        public string Time1 = string.Empty;
        public string Time2 = string.Empty;
    }
}
