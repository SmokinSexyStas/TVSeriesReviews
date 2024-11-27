using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.Services;
using TVSeriesReviews.WPF.Views;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class AuthorizationViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserSessionService _userSessionService;
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
        public DelegateCommand AuthorizeUserCommand {  get; set; }
        public DelegateCommand NavigateRegistrationCommand { get; set; }

        public AuthorizationViewModel(IRegionManager regionManager, IUserSessionService userSessionService)
        {
            _regionManager = regionManager;
            _userSessionService = userSessionService;
            _login = string.Empty;
            _password = string.Empty;
            _errorMessage = string.Empty;

            AuthorizeUserCommand = new DelegateCommand(AuthorizeUser);
            NavigateRegistrationCommand = new DelegateCommand(NavigateRegistration);
        }


        private void AuthorizeUser()
        {
            _user = new User { Login = _login, Password = _password };
            _user = DataWorker.GetUser(_user);
            if (_user != null)
            {
                ErrorMessage = string.Empty;

                _userSessionService.UpdateUser(_user);

                _regionManager.RequestNavigate("ContentRegion", nameof(HomeView), AuthorizationComplete);
            }
            else
            {
                ErrorMessage = "Authorization error";
            }
        }

        private void AuthorizationComplete(NavigationResult navigationResult)
        {
            MessageBox.Show($"Welcome {Login}", "Authorization Complete", MessageBoxButton.OK);
        }

        private void NavigateRegistration()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(RegistrationView));
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
