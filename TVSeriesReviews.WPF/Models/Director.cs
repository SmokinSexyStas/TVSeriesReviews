namespace TVSeriesReviews.WPF.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        List<TVShowDirector> TVShowsDirector { get; } = new List<TVShowDirector>();

        public void Initialize(string name)
        {
            Name = name;
        }
    }
}