using System.Data.Entity;

namespace WpfTest.View
{
    /// <summary>
    /// Represents the application's database context.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        // Gets or sets the collection of users in the database.
        public DbSet<User> Users { get; set; }
        // Gets or sets the collection of projects in the database.
        public DbSet<Project> Projects { get; set; }
        
        //Initializes a new instance of the ApplicationContext class with the specified connection string.
        public ApplicationContext() : base("DefaultConnection") { }
    }
}