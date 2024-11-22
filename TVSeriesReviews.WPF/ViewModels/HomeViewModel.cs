using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.Views;
using TVSeriesReviews.WPF.ViewModels;


namespace TVSeriesReviews.WPF.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public ObservableCollection<TVShow> TVShows { get; set; }
        public ObservableCollection<Genre> genres { get; set; } = new ObservableCollection<Genre>();
        private TVShow? _selectedTVShow;
        public TVShow? SelectedTVShow
        {
            get => _selectedTVShow;
            set
            {
                _selectedTVShow = value;
                SetProperty(ref _selectedTVShow, value);

                NavigateTVShowCommand.Execute(_selectedTVShow);
            }
        }

        public DelegateCommand<TVShow> NavigateTVShowCommand { get; set; }

        public HomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            var shows = DataWorker.GetAllTVShows();
            TVShows = new ObservableCollection<TVShow>(shows);

            _selectedTVShow = null;

            NavigateTVShowCommand = new DelegateCommand<TVShow>(NavigateTVShow);
        }


        private void NavigateTVShow(TVShow tvShow)
        {
            TVShow show = DataWorker.GetCompleteTVShow(tvShow.Id);
            if (show != null)
            {
                var parameter = new NavigationParameters();
                parameter.Add("TVShow", show);
                _regionManager.RequestNavigate("ContentRegion", nameof(TVShowView), parameter);
            }
            else
            {
                var parameter = new NavigationParameters();
                parameter.Add("Message", "TV show was not found");
                _regionManager.RequestNavigate("ContentRegion", nameof(ErrorView), parameter);
            }
        }

    }
}
