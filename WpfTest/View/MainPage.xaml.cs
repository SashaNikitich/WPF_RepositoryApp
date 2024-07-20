using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            // Load projects from the database and display them in the navigation view
            LoadProjectsFromDatabase();
        }

        private void LoadProjectsFromDatabase()
        {
            // Using a new database context to interact with the database
            using (var db = new ApplicationContext())
            {
                // Retrieve all projects from the database
                var projects = db.Projects.ToList();
                
                // Add each project to the navigation view
                foreach (var project in projects)
                {
                    AddNewProjectNavItem(project);
                }
            }
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the create project window as a dialog
            var createProjectWindow = new CreateProjectWindow();
            if (createProjectWindow.ShowDialog() == true)
            {
                // Create a new project based on user input
                var project = new Project
                {
                    Name = createProjectWindow.ProjectName,
                    GitHubLink = createProjectWindow.GitHubLink,
                    Description = createProjectWindow.ProjectDescription
                };

                // Add the new project to the database
                using (var db = new ApplicationContext())
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                }

                // Add the new project to the navigation view and navigate to its page
                AddNewProjectNavItem(project);
                NavigateToProjectPage(project);
            }
        }

        private void AddNewProjectNavItem(Project project)
        {
            // Create a new navigation view item for the project
            var newNavItem = new NavigationViewItem
            {
                Content = project.Name,
                Tag = project,
                Icon = new SymbolIcon { Symbol = SymbolRegular.Archive16 }
            };

            // Subscribe to the click event to handle navigation
            newNavItem.Click += NavigationViewItem_Click;
            // Add the new item to the navigation view
            ProjectsNavigationView.MenuItems.Add(newNavItem);
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            // Handle navigation when a navigation view item is clicked
            if (sender is NavigationViewItem selectedItem && selectedItem.Tag is Project project)
            {
                // Navigate to the project page
                NavigateToProjectPage(project);
            }
        }

        private void NavigateToProjectPage(Project project)
        {
            // Display the project page in the main frame
            MainFrame.Content = new ProjectPage(project);
        }
    }
}
