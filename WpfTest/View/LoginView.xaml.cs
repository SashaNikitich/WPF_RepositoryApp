using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly ApplicationContext db;

        public LoginView()
        {
            InitializeComponent();
            // Initialize the database context
            db = new ApplicationContext();
        }

        private void Login_Btn(object sender, RoutedEventArgs e)
        {
            // Trim the input values for login and password
            string login = Login_tb.Text.Trim();
            string pass = Login_pb.Password.Trim();

            // Validate the login and password fields
            ValidateLoginFields(login, pass);

            // If both login and password fields are valid
            if (IsValidLoginFields(login, pass))
            {
                // Try to find the user in the database
                User authUser = db.Users.FirstOrDefault(b => b.Login == login && b.Pass == pass);

                // If the user is found, navigate to the main page
                if (authUser != null)
                {
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                    this.Close(); // Close the login window
                }
                else
                {
                    // Show an error message if login or password is incorrect
                    MessageBox.Show("Incorrect password or login");
                }
            }
        }

        private void ValidateLoginFields(string login, string pass)
        {
            // Get validation messages for password and set the ToolTip and Background color accordingly
            string passwordValidationMessage = GetPasswordValidationMessage(pass);
            Login_pb.ToolTip = passwordValidationMessage;
            Login_pb.Background = GetValidationBackgroundColor(passwordValidationMessage);

            // Get validation messages for login and set the ToolTip and Background color accordingly
            string usernameValidationMessage = GetUsernameValidationMessage(login);
            Login_tb.ToolTip = usernameValidationMessage;
            Login_tb.Background = GetValidationBackgroundColor(usernameValidationMessage);
        }

        private string GetPasswordValidationMessage(string pass)
        {
            // Return appropriate validation message for password
            if (string.IsNullOrWhiteSpace(pass))
                return "Input your password";
            if (pass.Length < 5)
                return "Min 5 symbols";
            if (pass.Length > 20)
                return "Max 20 symbols";

            return null; // No validation error
        }

        private string GetUsernameValidationMessage(string login)
        {
            // Return appropriate validation message for username
            return string.IsNullOrWhiteSpace(login) ? "Input your username" : null;
        }

        private Brush GetValidationBackgroundColor(string toolTip)
        {
            // Set background color based on whether there's a validation message
            return string.IsNullOrEmpty(toolTip) ? Brushes.White : Brushes.Pink;
        }

        private bool IsValidLoginFields(string login, string pass)
        {
            // Check if both login and password fields have no validation errors
            return string.IsNullOrWhiteSpace(GetPasswordValidationMessage(pass)) && 
                   string.IsNullOrWhiteSpace(GetUsernameValidationMessage(login));
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // If Enter key is pressed, trigger the login button click event
            if (e.Key == Key.Enter)
            {
                Login_Btn(sender, e);
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            // Open the registration window and close the login window
            RegisterView registerWindow = new RegisterView();
            registerWindow.Show();
            this.Close();
        }
    }
}
