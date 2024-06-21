using System.Windows.Controls;

namespace WpfTest.View
{
    public partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            InitializeComponent();
        }

        public ProjectPage(Project project) : this()
        {
            DataContext = project;
        }
    }
}