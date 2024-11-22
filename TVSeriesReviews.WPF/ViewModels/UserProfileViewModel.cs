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
    public class UserProfileViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserSessionService _userSessionService;
        private User? _user;
        public User? User { get { return _user; } set { _user = value; } }
        private string? _login;
        public string? Login { get { return _login; } set { _login = value; } }

        public DelegateCommand ExitProfileCommand { get; set; }

        public UserProfileViewModel(IRegionManager regionManager, IUserSessionService userSessionService)
        {
            _regionManager = regionManager;
            _userSessionService = userSessionService;

            User = _userSessionService.CurrentUser;
            Login = User?.Login;

            ExitProfileCommand = new DelegateCommand(ExitProfile);
        }

        private void ExitProfile()
        {
            _userSessionService.UpdateUser(null);

            _regionManager.RequestNavigate("ContentRegion", nameof(HomeView));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
