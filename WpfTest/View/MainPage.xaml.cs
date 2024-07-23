using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using System.Linq;

namespace WpfTest.View
{
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            LoadProjectsFromDatabase();
        }

        private void LoadProjectsFromDatabase()
        {
            using (var db = new ApplicationContext())
            {
                var projects = db.Projects.ToList();
                foreach (var project in projects)
                {
                    AddNewProjectNavItem(project);
                }
            }
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var createProjectWindow = new CreateProjectWindow();
            if (createProjectWindow.ShowDialog() == true)
            {
                var project = new Project
                {
                    Name = createProjectWindow.ProjectName,
                    GitHubLink = createProjectWindow.GitHubLink,
                    Description = createProjectWindow.ProjectDescription
                };

                using (var db = new ApplicationContext())
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                }

                AddNewProjectNavItem(project);
                NavigateToProjectPage(project);
            }
        }

        private void AddNewProjectNavItem(Project project)
        {
            var newNavItem = new NavigationViewItem
            {
                Content = project.Name,
                Tag = project,
                Icon = new SymbolIcon { Symbol = SymbolRegular.Archive16 }
            };

            newNavItem.Click += NavigationViewItem_Click;
            ProjectsNavigationView.MenuItems.Add(newNavItem);
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationViewItem selectedItem && selectedItem.Tag is Project project)
            {
                NavigateToProjectPage(project);
            }
        }

        private void NavigateToProjectPage(Project project)
        {
            var projectPage = new ProjectPage(project);
            projectPage.ProjectDeleted += OnProjectDeleted;
            MainFrame.Content = projectPage;
        }

        private void OnProjectDeleted(object sender, Project project)
        {
            var itemToRemove = ProjectsNavigationView.MenuItems.OfType<NavigationViewItem>()
                .FirstOrDefault(i => i.Tag == project);

            if (itemToRemove != null)
            {
                ProjectsNavigationView.MenuItems.Remove(itemToRemove);
            }

            // Clear the project page content
            MainFrame.Content = null;
        }
    }
}
