using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateErrorCommand { get; set; }
        public ICommand NavigateAuthorizationCommand { get; set; }

        public ViewModelBase()
        {
            NavigateHomeCommand = new RelayCommand(NavigateHome);
            NavigateErrorCommand = new RelayCommand(ShowError);
            NavigateAuthorizationCommand = new RelayCommand(NavigateAuthorization);
        }

        protected void NavigateHome()
        {
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            mainViewModel?.NavigateHome();
        }

        protected void ShowError()
        {
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            mainViewModel?.NavigateError();
        }

        protected void NavigateAuthorization()
        {
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            mainViewModel?.NavigateAuthorization();
        }
    }
}