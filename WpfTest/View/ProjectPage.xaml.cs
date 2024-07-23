using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WpfTest.View
{
    public partial class ProjectPage : Page
    {
        private readonly Project _project;

        public event EventHandler<Project> ProjectDeleted;

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
                DeleteProjectFromDatabase();
                ProjectDeleted?.Invoke(this, _project);
                MessageBox.Show("Project deleted successfully!");
                NavigationService?.GoBack();
            }
        }

        private void DeleteProjectFromDatabase()
        {
            using (var db = new ApplicationContext())
            {
                var projectToRemove = db.Projects.SingleOrDefault(p => p.Id == _project.Id);
                if (projectToRemove != null)
                {
                    db.Projects.Remove(projectToRemove);
                    db.SaveChanges();
                }
            }
        }
    }
}