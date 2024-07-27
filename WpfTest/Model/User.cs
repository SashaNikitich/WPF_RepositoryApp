namespace WpfTest.View;

public class User
{
    public int id { get; set; }

    public string Login { get; set; }
    
    public string Pass { get; set; }

    public User() {}
    
    public User(string login, string pass)
    {
        Login = login;
        Pass = pass;
    }
}