using System.Data.Entity;

namespace WpfTest.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext() : base(Constants.DefaultConnectionString) { }
    }
}
