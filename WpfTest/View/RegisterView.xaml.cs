using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfTest.ViewModel;


namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }
    }
}
