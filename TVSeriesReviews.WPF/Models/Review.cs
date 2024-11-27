using Microsoft.Extensions.Internal;
using System.Security.RightsManagement;

namespace TVSeriesReviews.WPF.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public TVShow? TVShow { get; set; }
        public string? Text { get; set; }
        // Rate for tv show
        public int Rate { get; set; }
        // Rate for this review
        public int Users_Rate {  get; set; }
        public DateTimeOffset? DateWritten { get; set; }
        public List<ReviewLike> ReviewLikes { get; } = new List<ReviewLike>();   

    }
}