using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TVSeriesReviews.WPF.Models.Data
{
    public static class DataWorker
    {
        // tvshow
        public static TVShow GetCompleteTVShow(int id)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow? tvShow = db.TVShows.Include(tvShow => tvShow.TVShowDirectors)
                    .ThenInclude(tvShowDirector => tvShowDirector.Director)
                .Include(tvShow => tvShow.TVShowGenres)
                    .ThenInclude(tvShowGenre => tvShowGenre.Genre)
                .Include(tvShow => tvShow.TVShowActors)
                    .ThenInclude(tvShowActor => tvShowActor.Actor)
                .Include(tvShow => tvShow.Seasons)
                    .ThenInclude(tvShowSeason => tvShowSeason.Episodes)
                .Include(tvShow => tvShow.Reviews)
                    .ThenInclude(tvShowReview => tvShowReview.User)
                .Include(tvShow => tvShow.Reviews)
                    .ThenInclude(tvShowReview => tvShowReview.ReviewLikes)
                .FirstOrDefault(tvShow => tvShow.Id == id);

                return tvShow;
            }
        }

        public static string CreateTVShow(string title, string description = "")
        {
            string result = "Creation fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow tvShow = new TVShow();
                tvShow.Title = title;
                tvShow.Description = description;
                db.TVShows.Add(tvShow);
                db.SaveChanges();
                result = "Successfully created";
            }
            return result;
        }

        public static List<TVShow> GetAllTVShows()
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                List<TVShow> result = db.TVShows.ToList();
                return result;
            }
        }

        public static List<TVShow> GetFilteredTVShows(string title, List<Genre> selectedGenres, string directorName, string sortingOption)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                var query = db.TVShows.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(tv => EF.Functions.Like(tv.Title.ToLower(), $"%{title.ToLower()}%"));
                }

                if (selectedGenres != null && selectedGenres.Any())
                {
                    var selectedGenreIds = selectedGenres.Select(g => g.Id).ToList();
                    query = query.Where(tvShow =>
                        selectedGenreIds.All(genreId =>
                            tvShow.TVShowGenres.Any(tvShowGenre => tvShowGenre.Genre != null && tvShowGenre.Genre.Id == genreId)));
                }

                if (!string.IsNullOrEmpty(directorName))
                {
                    query = query.Where(tvShow => tvShow.TVShowDirectors.Any(tvShowDirector => 
                        EF.Functions.Like(tvShowDirector.Director.Name.ToLower(), $"%{directorName.ToLower()}%"))); 
                }

                query = sortingOption switch
                {
                    "Rating (Ascending)" => query.OrderBy(tvShow => tvShow.Rate),
                    "Rating (Descending)" => query.OrderByDescending(tvShow => tvShow.Rate),
                    "Title (A-Z)" => query.OrderBy(tvShow => tvShow.Title),
                    "Title (Z-A)" => query.OrderByDescending(tvShow => tvShow.Title),
                    "Release Year (Ascending)" => query.OrderBy(tvShow => tvShow.ReleaseYear),
                    "Release Year (Descending)" => query.OrderByDescending(tvShow => tvShow.ReleaseYear),
                    _ => query
                };

                query = query
                    .Include(tvShow => tvShow.TVShowGenres)
                        .ThenInclude(tvShowGenre => tvShowGenre.Genre)
                    .Include(tvShow => tvShow.TVShowDirectors)
                        .ThenInclude(tvShowDirector => tvShowDirector.Director);

                return query.ToList();
            }
        }

        public static bool UpdateTVShowRate(TVShow tvShow)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow? show = db.TVShows.FirstOrDefault(s => s.Id == tvShow.Id);
                if (show != null)
                {
                    show.Rate = tvShow.Rate;
                    int result = db.SaveChanges();
                    return result > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string DeleteTVShow(TVShow tvShow)
        {
            string result = "Delete fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (tvShow != null)
                {
                    db.TVShows.Remove(tvShow);
                    db.SaveChanges();
                    result = "Successfully deleted";
                }
            }
            return result;
        }

        // User
        public static bool CreateUser(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (db.Users.Any(u => u.Login == user.Login))
                {
                    return false;
                }
                else
                {
                    byte[] salt;
                    user.Password = Security.HashPassword(user.Password, out salt);
                    user.Salt = Convert.ToBase64String(salt);

                    db.Users.Add(user);
                    int savedRecords = db.SaveChanges();
                    return savedRecords > 0;
                }
            }
        }

        public static User GetUser(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? dbUser = db.Users?.FirstOrDefault(u => u.Login == user.Login);
                if (dbUser != null)
                {
                    byte[] salt = Convert.FromBase64String(dbUser.Salt);

                    bool isPasswordValid = Security.VerifyPassword(user.Password, dbUser.Password, salt);

                    return dbUser;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string UpdateUser(User user, string login, string password)
        {
            string result = "Update fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? User = db.Users.FirstOrDefault(u => u.Id == user.Id);
                if (User != null)
                {
                    User.Login = login;
                    User.Password = password;
                    db.SaveChanges();
                    result = "Successfully updated";
                }
            }
            return result;
        }

        public static bool DeleteUser(User user)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                User? u = db.Users.FirstOrDefault(u => u.Login == user.Login);
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Genres
        public static List<Genre> GetAllGenres()
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                List<Genre> genres = db.Genres.ToList();
                return genres;
            }
        }


        // Review
        public static bool CreateReview(Review review)
        {
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                TVShow? existingTVShow = db.TVShows.Find(review.TVShow.Id);
                User? existingUser = db.Users.Find(review.User.Id);
                if (existingTVShow != null && existingUser != null)
                {
                    review.TVShow = existingTVShow;
                    review.User = existingUser;

                    db.Reviews.Add(review);
                    int savedRecords = db.SaveChanges();
                    return savedRecords > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string UpdateReview(Review review, string text, int rate, int usersRate)
        {
            string result = "Update fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                Review? Review = db.Reviews.FirstOrDefault(r => r.Id == review.Id);
                if (Review != null)
                {
                    Review.Text = text;
                    Review.Rate = rate;
                    Review.Users_Rate = usersRate;
                    db.SaveChanges();
                    result = "Successfully updated";
                }
            }
            return result;
        }

        public static string DeleteReview(Review review)
        {
            string result = "Delete fail";
            using (TVSeriesReviewsContext db = new TVSeriesReviewsContext())
            {
                if (review != null)
                {
                    db.Reviews.Remove(review);
                    db.SaveChanges();
                    result = "Successfully deleted";
                }
            }
            return result;
        }
    }
}
