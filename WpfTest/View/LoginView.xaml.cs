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

            if (pass.Length < 5)
            {
                Login_pb.ToolTip = "Min 5 symbols";
                Login_pb.Background = Brushes.Pink;
            }
            else if (pass.Length > 20)
            {
                Login_pb.ToolTip = "Max 20 symbols";
                Login_pb.Background = Brushes.Pink;
            }
            else if (pass.Length == 0)
            {
                Login_pb.ToolTip = "Input your password";
                Login_pb.Background = Brushes.Pink;
            }
            else if (pass.Length == 0)
            {
                Login_tb.ToolTip = "Input your username";
                Login_tb.Background = Brushes.Pink;
            }
            else
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("incorrect password or login");
                }
            }
        }
        
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Btn(sender, e);
            }
        }
        
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterView registerWindow = new RegisterView();
            registerWindow.Show();
            this.Close();
        }
    }
}