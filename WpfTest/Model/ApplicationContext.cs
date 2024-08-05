using System.Data.Entity;
using WpfTest.View;

namespace WpfTest.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext() : base(Constants.DefaultConnectionString) { }
    }
}
