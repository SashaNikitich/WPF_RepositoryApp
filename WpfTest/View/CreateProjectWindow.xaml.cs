using WpfTest.ViewModel;

namespace WpfTest.View
{
    public partial class CreateProjectWindow
    {

        public CreateProjectWindow()
        {
            InitializeComponent();
            CreateProjectWindowViewModel vm = new CreateProjectWindowViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        public string? ProjectName => (DataContext as CreateProjectWindowViewModel)?.Name;
        public string? GitHubLink => (DataContext as CreateProjectWindowViewModel)?.GitHubLink;
        public string? ProjectDescription => (DataContext as CreateProjectWindowViewModel)?.Description;
    }
}