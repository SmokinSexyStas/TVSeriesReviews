using TVSeriesReviews.WPF.Models.Data;

class Program
{
    static void Main(string[] args)
    {
        string createResult = DataWorker.CreateTVShow("Test Show", "This is a test description.");
        Console.WriteLine(createResult);

        var tvShows = DataWorker.GetAllTVShows();
        Console.WriteLine("All TV Shows:");
        foreach (var show in tvShows)
        {
            Console.WriteLine($"- {show.Title}: {show.Description}");
        }

        if (tvShows.Any())
        {
            var tvShow = tvShows.First();
            string updateResult = DataWorker.UpdateTVShow(tvShow, "Updated Title", "Updated Description");
            Console.WriteLine(updateResult); 
        }

        if (tvShows.Any())
        {
            var tvShow = tvShows.First();
            string deleteResult = DataWorker.DeleteTVShow(tvShow);
            Console.WriteLine(deleteResult); 
        }

        var updatedTVShows = DataWorker.GetAllTVShows();
        Console.WriteLine("All TV Shows after deletion:");
        foreach (var show in updatedTVShows)
        {
            Console.WriteLine($"- {show.Title}: {show.Description}");
        }
        
        Console.ReadKey();
    }
}
