using System.Windows;

namespace WpfTest.View
{
    public partial class CreateProjectWindow
    {
        public string ProjectName => ProjectNameTextBox.Text;
        public string GitHubLink => GitHubLinkTextBox.Text;
        public string ProjectDescription => ProjectDescriptionTextBox.Text;

        public CreateProjectWindow()
        {
            InitializeComponent();
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}