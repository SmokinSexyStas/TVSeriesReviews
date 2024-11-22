using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.Views;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class RegistrationViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private User? _user;
        public User? User { get { return _user; } set { _user = value; } }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand RegistrationCommand { get; set; }

        public RegistrationViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _login = string.Empty;
            _password = string.Empty;
            _errorMessage = string.Empty;

            RegistrationCommand = new DelegateCommand(Registration);
        }

        private void Registration()
        {
            if (_password == string.Empty || _login == string.Empty)
            {
                ErrorMessage = "All fields must be filled";
            }
            else if (_password.Length < 8)
            {
                ErrorMessage = "Password shuld be at least 8 characters long";
            }
            else
            {
                _user = new User() { Login = _login, Password = _password };
                if (DataWorker.CreateUser(_user))
                {
                    _regionManager.RequestNavigate("ContentRegion", nameof(AuthorizationView), RegistrationComplete);
                }
                else
                {
                    ErrorMessage = "User with this login already exists";
                }
            }

        }

        private void RegistrationComplete(NavigationResult result)
        {
            MessageBox.Show($"Success", "Registration succeeded", MessageBoxButton.OK);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
