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
    public class HomeViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        public ObservableCollection<TVShow> TVShows { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Genre> SelectedGenres { get; set; }
        public ObservableCollection<string> SortingOptions { get; set; }
        public string? SearchText { get; set; }
        public string? SearchResultText { get; set; }
        public string SelectedSortingOption { get; set; }
        public string DirectorName { get; set; }
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
        public DelegateCommand ApplyFiltersCommand { get; set; }

        public HomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            var shows = DataWorker.GetAllTVShows();
            TVShows = new ObservableCollection<TVShow>(shows);
            var genres = DataWorker.GetAllGenres();
            Genres = new ObservableCollection<Genre>(genres);

            SortingOptions = new ObservableCollection<string>
            {
                "Rating (Ascending)",
                "Rating (Descending)",
                "Title (A-Z)",
                "Title (Z-A)",
                "Release Year (Ascending)",
                "Release Year (Descending)"
            };

            SelectedGenres = new ObservableCollection<Genre>();
            DirectorName = string.Empty;
            SelectedSortingOption = SortingOptions[1];

            _selectedTVShow = null;

            NavigateTVShowCommand = new DelegateCommand<TVShow>(NavigateTVShow);
            ApplyFiltersCommand = new DelegateCommand(ApplyFilters);

            ApplyFilters();
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

        private void ApplyFilters()
        {
            List<TVShow> filteredTVShows = DataWorker.GetFilteredTVShows(SearchText, SelectedGenres.ToList(), DirectorName, SelectedSortingOption);

            TVShows.Clear();
            foreach(TVShow tvShow in filteredTVShows)
            {
                TVShows.Add(tvShow);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SearchText = navigationContext.Parameters["SearchText"] as String;
            if (String.IsNullOrEmpty(SearchText))
            {
                SearchText = string.Empty;
                SearchResultText = string.Empty;
            }
            else
            {
                SearchResultText = $"Results for \"{SearchText}\"";
            }
            ApplyFilters();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
