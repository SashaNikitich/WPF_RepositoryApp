using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FluentValidation.Results;
using WpfTest.ViewModel;


namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        ///private ApplicationContext db;
        ///private readonly LoginValidator validator; 
        
        public LoginView()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
        }

        /*private void Login_Btn(object sender, RoutedEventArgs e)
        {
            var viewModel = new RegisterModel
            {
                Login = Login_tb.Text.Trim(),
                Password = Login_pb.Password.Trim()
            };

            ValidationResult results = validator.Validate(viewModel);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    if (failure.PropertyName == nameof(viewModel.Login))
                    {
                        Login_tb.ToolTip = failure.ErrorMessage;
                        Login_tb.Background = Brushes.Pink;
                    }
                    else if (failure.PropertyName == nameof(viewModel.Password))
                    {
                        Login_pb.ToolTip = failure.ErrorMessage;
                        Login_pb.Background = Brushes.Pink;
                    }
                }
            }
            else
            {
                Login_tb.ToolTip = null;
                Login_tb.Background = Brushes.White;
                Login_pb.ToolTip = null;
                Login_pb.Background = Brushes.White;
            }

            User authUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                authUser = db.Users.FirstOrDefault(b => b.Login == viewModel.Login && b.Pass == viewModel.Password);
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
        
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Login_Btn(sender, e);
        }
        
        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterView registerWindow = new RegisterView();
            registerWindow.Show();
            this.Close();
        }*/
    }
}