namespace WpfTest.View
{
    /// <summary>
    /// Represents a user in the application.
    /// </summary>
    public class User
    {
        // Gets or sets the user's ID.
        public int Id { get; set; }

        // Private fields for login and password
        private string login;
        private string pass;
        
        // Gets or sets the user's login.
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        
        // Gets or sets the user's password.
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        
        // Initializes a new instance of the User class.
        public User() {}
        
        // Initializes a new instance of the User class with the specified login and password.
        public User(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
    }
}