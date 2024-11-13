namespace TVSeriesReviews.WPF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public List<Review> Reviews { get; } = new List<Review>();
        public List<UserTVShow> Watchlist { get; } = new List<UserTVShow>();
        public List<ReviewLike> ReviewLikes { get; } = new List<ReviewLike>();

        public void Initialize(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}