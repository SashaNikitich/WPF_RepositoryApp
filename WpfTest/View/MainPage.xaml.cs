using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace WpfTest.View
{
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var createProjectWindow = new CreateProjectWindow();
            if (createProjectWindow.ShowDialog() == true)
            {
                var projectName = createProjectWindow.ProjectName;
                var gitHubLink = createProjectWindow.GitHubLink;
                var projectDescription = createProjectWindow.ProjectDescription;

                AddNewProjectNavItem(projectName, gitHubLink, projectDescription);
                NavigateToProjectPage(projectName, gitHubLink, projectDescription);
            }
        }

        private class ProjectInfo
        {
            public string ProjectName { get; set; }
            public string GitHubLink { get; set; }
            public string ProjectDescription { get; set; }
        }

        private void AddNewProjectNavItem(string projectName, string gitHubLink, string projectDescription)
        {
            var newNavItem = new NavigationViewItem
            {
                Content = projectName,
                Tag = new ProjectInfo
                {
                    ProjectName = projectName,
                    GitHubLink = gitHubLink,
                    ProjectDescription = projectDescription
                }
            };
            
            newNavItem.Icon = new SymbolIcon
            {
                Symbol = SymbolRegular.Archive16
            };

            newNavItem.Click += NavigationViewItem_Click;
            ProjectsNavigationView.MenuItems.Add(newNavItem);
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationViewItem selectedItem && selectedItem.Tag is ProjectInfo projectInfo)
            {
                NavigateToProjectPage(projectInfo.ProjectName, projectInfo.GitHubLink, projectInfo.ProjectDescription);
            }
        }

        private void NavigateToProjectPage(string projectName, string gitHubLink, string projectDescription)
        {
            var project = new Project
            {
                Name = projectName,
                GitHubLink = gitHubLink,
                Description = projectDescription
            };

            MainFrame.Content = new ProjectPage(project);
        }
    }
}