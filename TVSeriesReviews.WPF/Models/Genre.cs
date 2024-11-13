namespace TVSeriesReviews.WPF.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TVShowGenre> TVShowGenres { get; } = new List<TVShowGenre>();
        public void Initialize(string name)
        {
            Name = name;
        }
    }
}