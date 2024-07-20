using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private ApplicationContext db;
        
        public LoginView()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Login_Btn(object sender, RoutedEventArgs e)
        {
            string login = Login_tb.Text.Trim();
            string pass = Login_pb.Password.Trim();

            Login_pb.ToolTip = pass.Length < 5 ? "Min 5 symbols" :
                pass.Length > 20 ? "Max 20 symbols" :
                pass.Length == 0 ? "Input your password" : null;
            Login_pb.Background = pass.Length < 5 || pass.Length > 20 || pass.Length == 0 ? Brushes.Pink : Brushes.White;

            Login_tb.ToolTip = login.Length == 0 ? "Input your username" : null;
            Login_tb.Background = login.Length == 0 ? Brushes.Pink : Brushes.White;

            if (Login_pb.ToolTip == null && Login_tb.ToolTip == null)
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.FirstOrDefault(b => b.Login == login && b.Pass == pass);
                }

                if (authUser != null)
                {
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password or login");
                }
            }
        }
        
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Login_Btn(sender, e);
        }
        
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterView registerWindow = new RegisterView();
            registerWindow.Show();
            this.Close();
        }
    }
}