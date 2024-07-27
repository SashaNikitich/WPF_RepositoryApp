using System.Data.Entity;

namespace WpfTest.View
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext() : base(Constants.DefaultConnectionString) { }
    }
}
