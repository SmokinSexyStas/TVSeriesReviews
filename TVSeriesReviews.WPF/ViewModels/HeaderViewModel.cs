using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Services;
using TVSeriesReviews.WPF.Views;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserSessionService _userSessionService;
        private string _searchText;
        public string? SearchText {  get => _searchText; set { SetProperty(ref _searchText, value); } }
        private string? _userLogin;
        public string? UserLogin { get => _userLogin; set { SetProperty(ref _userLogin, value); } }
        private User? _user;

        public User? User
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
                if (_user != null)
                {
                    UserLogin = _user.Login.ToString();
                }
                else
                {
                    UserLogin = "Log in";
                }
            }
        }

        public DelegateCommand NavigateHomeCommand { get; set; }
        public DelegateCommand NavigateAuthorizationOrProfileCommand { get; set; }
        public DelegateCommand<string> SearchCommand { get; set; }

        public HeaderViewModel(IRegionManager regionManager, IUserSessionService userSessionService)
        {
            _regionManager = regionManager;
            _userSessionService = userSessionService;
            UserLogin = "Log in";
            User = null;
            SearchText = String.Empty;

            _userSessionService.UserChanged += OnUserChanged;

            NavigateHomeCommand = new DelegateCommand(NavigateHome);
            NavigateAuthorizationOrProfileCommand = new DelegateCommand(NavigateAuthorizationOrProfile);
            SearchCommand = new DelegateCommand<string>(Search);
        }

        private void NavigateHome()
        {
            SearchText = String.Empty;
            _regionManager.RequestNavigate("ContentRegion", "HomeView");
        }

        private void NavigateAuthorizationOrProfile()
        {
            if (User == null)
            {
                _regionManager.RequestNavigate("ContentRegion", nameof(AuthorizationView));
            }
            else
            {
                _regionManager.RequestNavigate("ContentRegion", nameof(UserProfileView));
            }

        }

        private void OnUserChanged(User user)
        {
            User = user;
        }

        private void Search(string obj)
        {
            var parameter = new NavigationParameters();
            parameter.Add("SearchText", _searchText);
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeView), parameter);
        }
    }
}
