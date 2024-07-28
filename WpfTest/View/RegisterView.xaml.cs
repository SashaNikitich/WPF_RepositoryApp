using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfTest.View
{
    public partial class RegisterView : Window
    {
        
        private ApplicationContext db;
        public RegisterView()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Register_Btn(sender, e);
        }

        private void Register_Btn(object sender, RoutedEventArgs e)
        {
            string login = Register_tb.Text.Trim();
            string pass = Register_pb.Password.Trim();

            Register_pb.ToolTip = pass.Length < 5 ? "Min 5 symbols" :
                pass.Length > 20 ? "Max 20 symbols" :
                string.IsNullOrEmpty(pass) ? "Input your password" : null;
            Register_pb.Background = pass.Length < 5 || pass.Length > 20 || string.IsNullOrEmpty(pass) ? Brushes.Pink : Brushes.White;

            Register_tb.ToolTip = string.IsNullOrEmpty(login) ? "Input your username" : null;
            Register_tb.Background = string.IsNullOrEmpty(login) ? Brushes.Pink : Brushes.White;

            if (Register_pb.ToolTip == null && Register_tb.ToolTip == null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    User user = new User { Login = login, Pass = pass };
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                MessageBox.Show("Registration successful!");
                ClearFields();
            }
        }

        private void ClearFields()
        {
            Register_tb.Clear();
            Register_pb.Clear();
            Register_tb.Background = Brushes.Transparent;
            Register_pb.Background = Brushes.Transparent;
            
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void Change_method(object sender, RoutedEventArgs e)
        {
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }
    }
}
