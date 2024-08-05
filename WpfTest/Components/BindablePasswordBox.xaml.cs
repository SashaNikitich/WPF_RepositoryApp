using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfTest.Components;

public partial class BindablePasswordBox : UserControl
{
    private static bool _isPasswordChanging;

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                PasswordPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

    private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is BindablePasswordBox passwordBox)
        {
            _isPasswordChanging = true;
            passwordBox.UpdatePassword();
            _isPasswordChanging = false;
        }
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    public BindablePasswordBox()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = PasswordBox.Password;
    }

    private void UpdatePassword()
    {
        if (!_isPasswordChanging)
        {
            PasswordBox.Password = Password;
        }
    }
}