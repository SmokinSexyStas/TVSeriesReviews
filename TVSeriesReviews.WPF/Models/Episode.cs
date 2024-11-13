namespace TVSeriesReviews.WPF.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public Season? Season { get; private set; }
        public int Number { get; set;}
        public string? Name {  get; set; }
        public string? Description { get; set; }

        public void Initialize(Season season, int number, string name="", string description="") 
        {
            if (season != null)
            {
                Season = season;
                Number = number;
                Name = name;
                Description = description;
            }
        }

        public void ChangeSeason(Season season)
        {
            if (season != null)
            {
                Season = season;
            }
        }
    }
}