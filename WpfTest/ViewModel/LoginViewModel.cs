using System.Windows.Input;
using WpfTest.Commands;
using WpfTest.View;

namespace WpfTest.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginValidator _loginValidator;
        private string _login;
        private string _password;
        private string _loginError;
        private bool _isLoginSuccessful;

        public LoginViewModel()
        {
            _loginValidator = new LoginValidator();
            LoginCommand = new RelayCommand(OnLogin);
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string LoginError
        {
            get => _loginError;
            set
            {
                _loginError = value;
                OnPropertyChanged("LoginError");
            }
        }

        public bool IsLoginSuccessful
        {
            get => _isLoginSuccessful;
            set
            {
                _isLoginSuccessful = value;
                OnPropertyChanged("IsLoginSuccessful");
            }
        }

        public ICommand LoginCommand { get; }

        private void OnLogin(object parameter)
        {
            var results = _loginValidator.Validate(this);
            if (results.IsValid)
            {
                // Simulating a login check
                if (Login == "admin" && Password == "admin")
                {
                    RedirectToMainWindow();
                }
            }
        }
        
        private void RedirectToMainWindow()
        {
            var mainWindow = new MainPage();
            mainWindow.Show();
        }
    }
}