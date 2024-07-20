using System.Windows;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        // Properties to get the input values from the text boxes
        public string ProjectName => ProjectNameTextBox.Text;
        public string GitHubLink => GitHubLinkTextBox.Text;
        public string ProjectDescription => ProjectDescriptionTextBox.Text;

        public CreateProjectWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Create Project button click
        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the dialog result to true, indicating that the user wants to create the project
            DialogResult = true;
        }
    }
}