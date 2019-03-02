namespace Testboker.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentList")]
    public partial class ContentList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Img { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsShow { get; set; }

        public string Label { get; set; }

        public DateTime Time { get; set; }
    }
}
