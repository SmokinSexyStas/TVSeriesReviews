namespace TVSeriesReviews.WPF.Models
{
    public class Season
    {
        public int Id { get; set; }
        public TVShow? TVShow { get; private set; }
        public int Number { get; set; }
        public List<Episode> Episodes { get; } = new List<Episode>();
        public int EpisodesCount => Episodes.Count;

        public void Initialize(TVShow tvShow, int number)
        {
            TVShow = tvShow;
            Number = number;
        }

        public void ChangeTVShow(TVShow tvShow)
        {
            if (tvShow != null) 
            {
                TVShow = tvShow;
            }
        }

    }
}