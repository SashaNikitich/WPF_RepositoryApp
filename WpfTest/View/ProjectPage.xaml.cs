using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;
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