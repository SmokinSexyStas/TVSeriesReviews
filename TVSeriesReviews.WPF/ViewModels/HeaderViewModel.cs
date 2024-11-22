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
        private string? _userLogin;
        public string? UserLogin
        {
            get => _userLogin;
            set { SetProperty(ref _userLogin, value); }
        }
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

        public HeaderViewModel(IRegionManager regionManager, IUserSessionService userSessionService)
        {
            _regionManager = regionManager;
            _userSessionService = userSessionService;
            UserLogin = "Log in";
            User = null;

            _userSessionService.UserChanged += OnUserChanged;

            NavigateHomeCommand = new DelegateCommand(() => _regionManager.RequestNavigate("ContentRegion", "HomeView"));
            NavigateAuthorizationOrProfileCommand = new DelegateCommand(NavigateAuthorizationOrProfile);
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

        public IUserSessionService IUserSessionService
        {
            get => default;
            set
            {
            }
        }
    }
}
