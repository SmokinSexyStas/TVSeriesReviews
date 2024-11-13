namespace TVSeriesReviews.WPF.Models
{
    public class UserTVShow
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public TVShow? TVShow { get; set; }
        public void Initialize(User user, TVShow tvShow)
        {
            User = user;
            TVShow = tvShow;
        }
    }
}