using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class TVShowViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        public TVShow? TVShow { get; private set; }
        public string Directors { get; private set; }
        public string Genres { get; private set; }
        public string Actors { get; private set; }

        public TVShowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
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
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

    }
}
