using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTest.Commands;
using WpfTest.View;
using WpfTest.Model;

namespace WpfTest.ViewModel;

public class MainPageViewModel : BaseViewModel
{
    public ObservableCollection<Project> Projects { get; set; }

    private Project _selectedProject;
    private Page? _selectedProjectPage;

    public ICommand AddCommand { get; }

    public Project SelectedProject
    {
        get => _selectedProject;
        set
        {
            _selectedProject = value;
            OnPropertyChanged(nameof(SelectedProject));
            NavigateToProjectPage(value);

        }
    }

    public Page? SelectedProjectPage
    {
        get => _selectedProjectPage;
        set
        {
            _selectedProjectPage = value;
            OnPropertyChanged(nameof(SelectedProjectPage));
        }
    }

    public MainPageViewModel()
    {
        Projects = ProjectManager.GetProjects();
        AddCommand = new RelayCommand(Add, CanAdd);
    }

    private bool CanAdd(object arg)
    {
        return true;
    }

    private void Add(object obj)
    {
        CreateProjectWindow createProjectWindow = new CreateProjectWindow();
        if (createProjectWindow.ShowDialog() == true)
        {
            var project = new Project
            {
                Name = createProjectWindow.ProjectName,
                GitHubLink = createProjectWindow.GitHubLink,
                Description = createProjectWindow.ProjectDescription
            };

            ProjectManager.AddProject(project);
            Projects.Add(project);
            SelectedProject = project;
        }
    }

    private void NavigateToProjectPage(Project project)
    {
        SelectedProjectPage = new ProjectPage(project);
        if (SelectedProjectPage.DataContext is ProjectPageViewModel vm)
        {
            vm.ProjectDeleted += OnProjectDeleted;
        }
    }

    private void OnProjectDeleted(object? sender, Project project)
    {
        Projects.Remove(project);
        ProjectManager.DeleteProject(project);
        SelectedProjectPage = null;
    }
}