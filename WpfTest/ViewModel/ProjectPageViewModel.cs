using System.Windows.Input;
using WpfTest.Model;

namespace WpfTest.ViewModel;

public class ProjectPageViewModel : BaseViewModel
{
    public Project Project { get; }

    public event EventHandler<Project> ProjectDeleted;

    public ProjectPageViewModel(Project project)
    {
        Project = project;
    }

    public ICommand DeleteProjectCommand { get; }

    private bool CanDeleteProject(object parameter)
    {
        return true;
    }

    private void DeleteProject(object parameter)
    {
        ProjectDeleted?.Invoke(this, Project);
    }
}