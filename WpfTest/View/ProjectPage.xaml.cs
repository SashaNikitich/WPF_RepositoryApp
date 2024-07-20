using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private readonly Project _project;

        public ProjectPage()
        {
            InitializeComponent();
        }

        public ProjectPage(Project project) : this()
        {
            _project = project;
            DataContext = project; // Bind the project data to the UI
        }

        private void DeleteProject_Btn(object sender, RoutedEventArgs e)
        {
            // Confirm deletion with the user
            var result = MessageBox.Show("Are you sure?", "Delete Project", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // If user confirms deletion
            if (result == MessageBoxResult.Yes)
            {
                // Delete the project from the database
                DeleteProjectFromDatabase();

                // Show success message and navigate back to the previous page
                MessageBox.Show("Project deleted successfully!");
                NavigationService.GoBack(); // Navigate back to the previous page
            }
        }

        private void DeleteProjectFromDatabase()
        {
            // Use a new database context to interact with the database
            using (var db = new ApplicationContext())
            {
                // Find the project to remove by its name
                var projectToRemove = db.Projects.SingleOrDefault(p => p.Name == _project.Name);
                if (projectToRemove != null)
                {
                    db.Projects.Remove(projectToRemove); // Remove the project
                    db.SaveChanges(); // Save changes to the database
                }
            }
        }
    }
}