namespace Testboker.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginLog")]
    public partial class LoginLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string IP { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string Chrome { get; set; }
    }
}
