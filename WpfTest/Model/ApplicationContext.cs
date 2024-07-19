using System.Data.Entity;

namespace WpfTest.View;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public ApplicationContext() : base("DefaultConnection") {}
}