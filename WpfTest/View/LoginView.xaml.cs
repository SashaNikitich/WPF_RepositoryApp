using System.Windows;
using WpfTest.ViewModel;


namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel vm = new LoginViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}