using System.ComponentModel;
using System.Windows.Input;
using WpfTest.Commands;
using WpfTest.Model;
using FluentValidation.Results;
using WpfTest.Validators;
using WpfTest.View;

namespace WpfTest.ViewModel
{
    public class RegisterViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly RegisterValidator _registerValidator;
        private RegisterModel _registerModel;
        private string _registerError;
        private bool _isRegisterSuccessful;

        public RegisterViewModel()
        {
            _registerValidator = new RegisterValidator();
            _registerModel = new RegisterModel();
            RegisterCommand = new RelayCommand(OnRegister, CanRegister);
            RedirectToLoginPage = new RelayCommand(Redirect);
        }

        public RegisterModel RegisterModel
        {
            get => _registerModel;
            set
            {
                _registerModel = value;
                OnPropertyChanged(nameof(RegisterModel));
            }
        }

        public string RegisterError
        {
            get => _registerError;
            set
            {
                _registerError = value;
                OnPropertyChanged(nameof(RegisterError));
            }
        }

        public bool IsRegisterSuccessful
        {
            get => _isRegisterSuccessful;
            set
            {
                _isRegisterSuccessful = value;
                OnPropertyChanged(nameof(IsRegisterSuccessful));
            }
        }
        
        public ICommand RegisterCommand { get; }
        public ICommand RedirectToLoginPage { get; }

        private void OnRegister(object parameter)
        {
            ValidationResult results = _registerValidator.Validate(RegisterModel);
            if (results.IsValid)
            {
                // Simulating a login check
                IsRegisterSuccessful = true;
            }
            else
            {
                IsRegisterSuccessful = false;
                RegisterError = string.Join(Environment.NewLine, results.Errors.Select(e => e.ErrorMessage));
            }
        }

        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrEmpty(_registerModel.Login) && !string.IsNullOrEmpty(_registerModel.Password);
        }

        private void Redirect(object parameter)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _registerValidator.Validate(_registerModel).Errors.FirstOrDefault(error => error.PropertyName == columnName);
                return firstOrDefault != null ? firstOrDefault.ErrorMessage : string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var results = _registerValidator.Validate(_registerModel);
                return results != null && results.Errors.Any() ? string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray()) : string.Empty;
            }
        }
    }
}
