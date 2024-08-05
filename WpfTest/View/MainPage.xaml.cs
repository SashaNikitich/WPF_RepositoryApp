using System.Windows.Controls;
using WpfTest.ViewModel;

namespace WpfTest.View
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
