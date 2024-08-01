using System.ComponentModel;
using System.Windows.Input;
using WpfTest.Commands;
using WpfTest.Model;
using FluentValidation.Results;
using WpfTest.Validators;
using WpfTest.View;

namespace WpfTest.ViewModel
{
    public class LoginViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly LoginValidator _loginValidator;
        private LoginModel _loginModel;
        private string _loginError;
        private bool _isLoginSuccessful;

        public LoginViewModel()
        {
            _loginValidator = new LoginValidator();
            _loginModel = new LoginModel();
            LoginCommand = new RelayCommand(OnLogin, CanLogin);
            RedirectToRegisterPage = new RelayCommand(Redirect);
        }

        public LoginModel LoginModel
        {
            get => _loginModel;
            set
            {
                _loginModel = value;
                OnPropertyChanged(nameof(LoginModel));
            }
        }

        public string LoginError
        {
            get => _loginError;
            set
            {
                _loginError = value;
                OnPropertyChanged(nameof(LoginError));
            }
        }

        public bool IsLoginSuccessful
        {
            get => _isLoginSuccessful;
            set
            {
                _isLoginSuccessful = value;
                OnPropertyChanged(nameof(IsLoginSuccessful));
            }
        }
        
        public ICommand LoginCommand { get; }
        public ICommand RedirectToRegisterPage { get; }

        private void OnLogin(object parameter)
        {
            ValidationResult results = _loginValidator.Validate(LoginModel);
            if (results.IsValid)
            {
                // Simulating a login check
                if (_loginModel.Login == "admin" && _loginModel.Password == "admin")
                {
                    IsLoginSuccessful = true;
                    RedirectToMainWindow();
                }
                else
                {
                    IsLoginSuccessful = false;
                    LoginError = "Invalid username or password.";
                }
            }
            else
            {
                IsLoginSuccessful = false;
                LoginError = string.Join(Environment.NewLine, results.Errors.Select(e => e.ErrorMessage));
            }
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(_loginModel.Login) && !string.IsNullOrEmpty(_loginModel.Password);
        }

        private void RedirectToMainWindow()
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void Redirect(object parameter)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _loginValidator.Validate(_loginModel).Errors.FirstOrDefault(error => error.PropertyName == columnName);
                return firstOrDefault != null ? firstOrDefault.ErrorMessage : string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var results = _loginValidator.Validate(_loginModel);
                return results != null && results.Errors.Any() ? string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray()) : string.Empty;
            }
        }
    }
}
