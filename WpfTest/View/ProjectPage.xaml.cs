using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfTest.View
{
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
            DataContext = project;
        }
        
        private void DeleteProject_Btn(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Delete Project", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ApplicationContext())
                {
                    var projectToRemove = db.Projects.SingleOrDefault(p => p.Name == _project.Name);
                    if (projectToRemove != null)
                    {
                        db.Projects.Remove(projectToRemove);
                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Project deleted successfully!");
                NavigationService.GoBack(); // Navigate back to the previous page
            }
        }
    }
}