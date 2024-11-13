namespace TVSeriesReviews.WPF.Models
{
    public class TVShowDirector
    {
        public int Id { get; set; }
        public TVShow? TVShow { get; private set; }
        public Director? Director { get; private set; }

        public void Initialize(TVShow tvShow, Director director)
        {
            TVShow = tvShow;
            Director = director;
        }
    }
}