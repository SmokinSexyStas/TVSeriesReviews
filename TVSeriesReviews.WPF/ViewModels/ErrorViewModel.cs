using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TVSeriesReviews.WPF.ViewModels
{
    class ErrorViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private string _errorText;
        public string ErrorText { get => _errorText; set => _errorText = value; }
        public DelegateCommand NavigateHomeCommand { get; set; }
        public ErrorViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateHomeCommand = new DelegateCommand(NavigateHome);
        }

        private void NavigateHome()
        {
            _regionManager.RequestNavigate("ContentRegion", "HomeView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            ErrorText = navigationContext.Parameters["Message"].ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
