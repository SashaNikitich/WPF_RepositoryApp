using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTest.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

}