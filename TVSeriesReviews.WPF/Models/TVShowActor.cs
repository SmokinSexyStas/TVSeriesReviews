namespace TVSeriesReviews.WPF.Models
{
    public class TVShowActor
    {
        public int Id { get; set; }
        public TVShow? TVShow { get; private set; }
        public Actor? Actor { get; private set; }

        public void Initialize(TVShow tvShow, Actor actor)
        {
            TVShow = tvShow;
            Actor = actor;
        }
    }
}