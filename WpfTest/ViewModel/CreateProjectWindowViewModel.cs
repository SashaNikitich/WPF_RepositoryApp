using System.Windows.Input;
using WpfTest.Commands;
using WpfTest.Model;
using WpfTest.View;

namespace WpfTest.ViewModel;

public class CreateProjectWindowViewModel : BaseViewModel
{
    public ICommand AddProjectCommand { get; }
    public Action CloseAction { get; set; }
        
    private string? _name;
    private string? _gitHubLink;
    private string? _description;

    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string? GitHubLink
    {
        get => _gitHubLink;
        set
        {
            _gitHubLink = value;
            OnPropertyChanged(nameof(GitHubLink));
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public CreateProjectWindowViewModel()
    {
        AddProjectCommand = new RelayCommand(AddProject, CanAddProject);
    }

    private bool CanAddProject(object arg)
    {
        return true;
    }

    private void AddProject(object obj)
    {
        var project = new Project
        {
            Name = Name,
            GitHubLink = GitHubLink,
            Description = Description
        };

        ProjectManager.AddProject(project);
        CloseAction?.Invoke();
    }
}