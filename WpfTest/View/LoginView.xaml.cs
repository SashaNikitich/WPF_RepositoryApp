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
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Login_Btn(object sender, RoutedEventArgs e)
        {
            string username = Login_tb.Text.Trim();
            string password = Login_pb.Password.Trim();

            if (password.Length < 5) {
                Login_pb.ToolTip = "Min 5 symbols";
                Login_pb.Background = Brushes.Pink;
            } else if (password.Length > 20) {
                Login_pb.ToolTip = "Max 20 symbols";
                Login_pb.Background = Brushes.Pink;
            } else if (password.Length == 0) {
                Login_pb.ToolTip = "Input your password";
                Login_pb.Background = Brushes.Pink;
            } else if (username.Length == 0) {
                Login_tb.ToolTip = "Input your username";
                Login_tb.Background = Brushes.Pink;
            } else {
                //var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
                //if (user != null)
                //{
                //    MainWindow mainWindow = new MainWindow();
                //    mainWindow.Show();
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Incorrect username or password");
                //}
                
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Btn(sender, e);
            }
        }
    }
}