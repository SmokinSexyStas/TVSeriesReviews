namespace TVSeriesReviews.WPF.Models
{
    public class ReviewLike
    {
        public int Id { get; set; }
        public User? User { get; private set; }
        public Review? Review { get; private set; }
        public bool IsLike { get; set; }

        public void Initialize(int userId, int reviewId, bool isLike)
        {
            IsLike = isLike;
        }

        public void ChangeUser(User user)
        {
            if (user != null)
            {
                User = user;
            }
        }

        public void ChangeReview(Review review)
        {
            if (review != null)
            {
                Review = review;
            }
        }
    }
}