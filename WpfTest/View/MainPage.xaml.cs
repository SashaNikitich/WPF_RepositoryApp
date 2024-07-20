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
                var projectInfo = new ProjectInfo
                {
                    ProjectName = createProjectWindow.ProjectName,
                    GitHubLink = createProjectWindow.GitHubLink,
                    ProjectDescription = createProjectWindow.ProjectDescription
                };

                AddNewProjectNavItem(projectInfo);
                NavigateToProjectPage(projectInfo);
            }
        }

        private class ProjectInfo
        {
            public string ProjectName { get; set; }
            public string GitHubLink { get; set; }
            public string ProjectDescription { get; set; }
        }

        private void AddNewProjectNavItem(ProjectInfo projectInfo)
        {
            var newNavItem = new NavigationViewItem
            {
                Content = projectInfo.ProjectName,
                Tag = projectInfo,
                Icon = new SymbolIcon { Symbol = SymbolRegular.Archive16 }
            };

            newNavItem.Click += NavigationViewItem_Click;
            ProjectsNavigationView.MenuItems.Add(newNavItem);
        }

        private void NavigationViewItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationViewItem selectedItem && selectedItem.Tag is ProjectInfo projectInfo)
            {
                NavigateToProjectPage(projectInfo);
            }
        }

        private void NavigateToProjectPage(ProjectInfo projectInfo)
        {
            MainFrame.Content = new ProjectPage(new Project
            {
                Name = projectInfo.ProjectName,
                GitHubLink = projectInfo.GitHubLink,
                Description = projectInfo.ProjectDescription
            });
        }
    }
}
