using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.Models
{
    public class TVShow
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Rate {  get; set; }
        public int? ReleaseYear {  get; set; }
        public string? PosterPath {  get; set; }
        public List<TVShowGenre> TVShowGenres { get; } = new List<TVShowGenre>();
        public List<TVShowDirector> TVShowDirectors { get; } = new List<TVShowDirector>();
        public List<TVShowActor> TVShowActors { get; } = new List<TVShowActor>();
        public List<Season> Seasons { get; } = new List<Season>();
        public List<Review> Reviews { get; } = new List<Review>();

    }
}
