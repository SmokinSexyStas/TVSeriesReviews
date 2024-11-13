using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.Models.Data
{
    public class TVSeriesReviewsContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewLike> ReviewLikes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<TVShowActor> TVShowActors { get; set; }
        public DbSet<TVShowDirector> TVShowDirectors { get; set; }
        public DbSet<TVShowGenre> TVShowGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTVShow> UserTVShows { get; set; }
        public string DbPath { get; }

        public TVSeriesReviewsContext()
        {
            DbPath = "Host=localhost;Database=TVSeries_Reviews_DB;Username=postgres;Password=tasia";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbPath);
    }
}
