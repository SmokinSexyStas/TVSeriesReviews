using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.Views;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserControl? _currentView;
        public UserControl? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            CurrentView = new HomeView();
        }

        public void NavigateTVShow(TVShow selectedShow)
        {
            TVShow tvShow = DataWorker.GetCompleteTVShow(selectedShow.Id);
            if (tvShow == null)
            {
                NavigateError();
            }
            else
            {
                CurrentView = new TVShowView(tvShow);
            }
        }

        public void NavigateHome()
        {
            CurrentView = new HomeView();
        }

        public void NavigateError()
        {
            CurrentView = new ErrorView();
        }

        public void NavigateAuthorization()
        {
            CurrentView = new AuthorizationView();
        }
    }
}
