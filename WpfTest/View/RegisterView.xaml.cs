using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfTest.View
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly ApplicationContext db;

        public RegisterView()
        {
            InitializeComponent();
            // Initialize the database context
            db = new ApplicationContext();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Allow dragging the window when the left mouse button is pressed
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // If Enter key is pressed, trigger the register button click event
            if (e.Key == Key.Enter)
            {
                Register_Btn(sender, e);
            }
        }

        private void Register_Btn(object sender, RoutedEventArgs e)
        {
            // Trim the input values for login and password
            string login = Register_tb.Text.Trim();
            string pass = Register_pb.Password.Trim();

            // Validate the fields
            ValidateFields(login, pass);

            // If both fields are valid, add the new user to the database
            if (IsValidFields())
            {
                // Use the existing database context to add and save the new user
                AddUserToDatabase(login, pass);

                // Show success message and clear fields
                MessageBox.Show("Registration successful!");
                ClearFields();
            }
        }

        private void ValidateFields(string login, string pass)
        {
            // Validate the password field
            Register_pb.ToolTip = GetPasswordValidationMessage(pass);
            Register_pb.Background = GetValidationBackgroundColor(Register_pb.ToolTip);

            // Validate the username field
            Register_tb.ToolTip = GetUsernameValidationMessage(login);
            Register_tb.Background = GetValidationBackgroundColor(Register_tb.ToolTip);
        }

        private string GetPasswordValidationMessage(string pass)
        {
            // Return appropriate validation message for password
            if (string.IsNullOrWhiteSpace(pass))
            {
                return "Input your password";
            }
            if (pass.Length < 5)
            {
                return "Min 5 symbols";
            }
            if (pass.Length > 20)
            {
                return "Max 20 symbols";
            }

            return null; // No validation error
        }

        private string GetUsernameValidationMessage(string login)
        {
            // Return appropriate validation message for username
            return string.IsNullOrWhiteSpace(login) ? "Input your username" : null;
        }

        private Brush GetValidationBackgroundColor(object toolTip)
        {
            // Set background color based on whether there's a validation message
            return string.IsNullOrEmpty(toolTip as string) ? Brushes.White : Brushes.Pink;
        }

        private bool IsValidFields()
        {
            // Check if both login and password fields have no validation errors
            return string.IsNullOrEmpty(Register_pb.ToolTip as string) &&
                   string.IsNullOrEmpty(Register_tb.ToolTip as string);
        }

        private void AddUserToDatabase(string login, string pass)
        {
            // Add the new user to the database and save changes
            User user = new User { Login = login, Pass = pass };
            db.Users.Add(user);
            db.SaveChanges();
        }

        private void ClearFields()
        {
            // Clear the input fields and reset background colors
            Register_tb.Clear();
            Register_pb.Clear();
            Register_tb.Background = Brushes.Transparent;
            Register_pb.Background = Brushes.Transparent;

            // Open the login window and close the registration window
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }

        private void Change_method(object sender, RoutedEventArgs e)
        {
            // Open the login window and close the registration window
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }
    }
}