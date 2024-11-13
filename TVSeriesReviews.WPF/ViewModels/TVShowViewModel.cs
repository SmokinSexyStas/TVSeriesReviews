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
    public class TVShowViewModel : ViewModelBase
    {
        public TVShow? TVShow { get; private set; }
        public string Directors { get; private set; }
        public string Genres { get; private set; }
        public string Actors { get; private set; }

        public TVShowViewModel(TVShow selectedShow)
        {
            TVShow = selectedShow;

            Directors = string.Join(", ", TVShow.TVShowDirectors.Select(d => d.Director?.Name));
            Genres = string.Join(", ", TVShow.TVShowGenres.Select(g => g.Genre?.Name));
            Actors = string.Join(", ", TVShow.TVShowActors.Select(a => a.Actor?.Name));
        }

    }
}
