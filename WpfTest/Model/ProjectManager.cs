using System.Collections.ObjectModel;

namespace WpfTest.Model;

public class ProjectManager
{
    private static readonly ObservableCollection<Project?> DataBaseProjects = [];

    public static ObservableCollection<Project> GetProjects()
    {
        return DataBaseProjects;
    }

    public static void AddProject(Project? project)
    {
        DataBaseProjects.Add(project);
    }

    public static void DeleteProject(Project project)
    {
        throw new NotImplementedException();
    }
}