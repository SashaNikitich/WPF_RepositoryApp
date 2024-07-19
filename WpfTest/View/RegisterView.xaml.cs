using System.Data.Entity;
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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Register_Btn(sender, e);
            }
        }

        private void Register_Btn(object sender, RoutedEventArgs e)
        {
            string login = Register_tb.Text.Trim();
            string pass = Register_pb.Password.Trim();

            if (pass.Length < 5)
            {
                Register_pb.ToolTip = "Min 5 symbols";
                Register_pb.Background = Brushes.Pink;
            }
            else if (pass.Length > 20)
            {
                Register_pb.ToolTip = "Max 20 symbols";
                Register_pb.Background = Brushes.Pink;
            }
            else if (pass.Length == 0)
            {
                Register_pb.ToolTip = "Input your password";
                Register_pb.Background = Brushes.Pink;
            }
            else if (pass.Length == 0)
            {
                Register_tb.ToolTip = "Input your username";
                Register_tb.Background = Brushes.Pink;
            }
            else
            {
                // Здесь можно добавить логику для регистрации нового пользователя,
                // например, добавление в базу данных или в файл

                MessageBox.Show("Registration successful!");
                ClearFields();
                
                User user = new User(login, pass);
                db.Users.Add(user);
                db.SaveChanges();
    
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
