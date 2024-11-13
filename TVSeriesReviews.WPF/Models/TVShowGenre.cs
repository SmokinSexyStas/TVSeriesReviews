using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.Models
{
    public class TVShowGenre
    {
        public int Id { get; set; }
        public TVShow? TVShow { get; private set; }
        public Genre? Genre { get; private set; }

        public void Initialize(TVShow tVShow, Genre genre)
        {
            TVShow = tVShow;
            Genre = genre;
        }
    }
}
