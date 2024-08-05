using System.Windows.Controls;
using WpfTest.Model;
using WpfTest.ViewModel;

namespace WpfTest.View
{
    public partial class ProjectPage : Page
    {
        public ProjectPage(Project? project)
        {
            InitializeComponent();
            DataContext = new ProjectPageViewModel(project);
        }
    }
}