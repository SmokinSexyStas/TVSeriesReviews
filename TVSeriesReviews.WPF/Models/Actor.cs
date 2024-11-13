namespace TVSeriesReviews.WPF.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        List<TVShowActor> TVShowsActor { get; } = new List<TVShowActor>();

        public void Initialize(string name)
        {
            Name = name;
        }
    }
}