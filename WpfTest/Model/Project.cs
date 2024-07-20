namespace WpfTest.View
{
    /// <summary>
    /// Represents a project in the application.
    /// </summary>
    public class Project
    {
        // Gets or sets the project's ID.
        public int Id { get; set; }
        // Gets or sets the project's name.
        public string Name { get; set; }
        // Gets or sets the project's GitHub link.
        public string GitHubLink { get; set; }
        // Gets or sets the project's description.
        public string Description { get; set; }
    }
}