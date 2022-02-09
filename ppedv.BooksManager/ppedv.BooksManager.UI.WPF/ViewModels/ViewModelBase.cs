using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ppedv.BooksManager.UI.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string proName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proName));
        }

        protected void OnThisPropertyChanged([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrWhiteSpace(propName))
                OnPropertyChanged(propName);
        }
    }
}
