using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class TVShowViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserSessionService _userSessionService;
        public TVShow? TVShow { get; private set; }
        public string Directors { get; private set; }
        public string Genres { get; private set; }
        public string Actors { get; private set; }
        public string? PosterPath { get; private set; }
        public ObservableCollection<Review> Reviews { get; private set; }
        public User? CurrentUser { get; private set; }
        private string? _userReview;
        public string? UserReview { get => _userReview; set { SetProperty(ref _userReview, value); } }
        private int _userRate;
        public int UserRate { get => _userRate; set { SetProperty(ref _userRate, value); } }

        public DelegateCommand PublishReviewCommand { get; set; }

        public TVShowViewModel(IRegionManager regionManager, IUserSessionService userSessionService)
        {
            _regionManager = regionManager;
            _userSessionService = userSessionService;

            CurrentUser = userSessionService.CurrentUser;

            // UserReview and UserRate temp initiallize
            UserReview = String.Empty;
            UserRate = 0;

            PublishReviewCommand = new DelegateCommand(PublishReview);
        }

        private void PublishReview()
        {
            if (CurrentUser != null)
            {
                Review review = new Review();
                review.User = CurrentUser;
                review.TVShow = TVShow;
                review.Text = UserReview;
                review.Rate = UserRate;
                review.Users_Rate = 0;
                review.DateWritten = DateTimeOffset.UtcNow;

                DataWorker.CreateReview(review);
                TVShow.Reviews.Add(review);
                Reviews.Add(review);

                //decimal newRate = (decimal)Reviews.Sum(x => x.Rate) / (decimal)Reviews.Count;
                //TVShow.Rate = newRate;
                //DataWorker.UpdateTVShowRate(TVShow);
                
                RefreshView();
            }
            else
            {
                MessageBox.Show("Only for authorized users", "Error", MessageBoxButton.OK);
            }
        }

        private void RefreshView()
        {
            TVShow show = DataWorker.GetCompleteTVShow(TVShow.Id);
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

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["TVShow"] as TVShow;
            if (param != null)
            {
                TVShow = (TVShow)param;

                Directors = string.Join(", ", TVShow.TVShowDirectors.Select(d => d.Director?.Name));
                Genres = string.Join(", ", TVShow.TVShowGenres.Select(g => g.Genre?.Name));
                Actors = string.Join(", ", TVShow.TVShowActors.Select(a => a.Actor?.Name));
                PosterPath = TVShow.PosterPath.ToString();

                Reviews = new ObservableCollection<Review>(TVShow.Reviews);
                
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

    }
}
