namespace Testboker.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestBoker : DbContext
    {
        public TestBoker()
            : base("name=TestBoker")
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<ContentList> ContentList { get; set; }
        public virtual DbSet<Exhibition> Exhibition { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
