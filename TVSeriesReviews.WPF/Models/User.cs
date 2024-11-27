namespace TVSeriesReviews.WPF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Salt {  get; set; }
        public string? Email { get; set; }
        public DateTimeOffset? RegistrationDate { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsBanned { get; set; }
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